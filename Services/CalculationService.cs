namespace TFGCalculator.Services;

using TFGCalculator.Models;

public class CalcTreeNode
{
    public string ItemId { get; set; } = "";
    public string ItemName { get; set; } = "";
    public string ItemIconUrl { get; set; } = "";
    public double RequiredPerSecond { get; set; }
    public Recipe? Recipe { get; set; }
    public int CurrentTierLevel { get; set; }
    public int CurrentCoilLevel { get; set; } = 1;
    public double MachineCount { get; set; }
    public double ActualEnergyPerTick { get; set; }
    public double ActualDurationTicks { get; set; }
    public List<CalcTreeNode> Children { get; set; } = new();
    public bool IsRawResource => Recipe == null && !NeedsRecipeSelection && !IsStorage;
    public bool NeedsRecipeSelection { get; set; }
    public List<Recipe> AvailableRecipes { get; set; } = new();
    public string NodeId { get; set; } = "";
    public bool IsStorage { get; set; }
    public bool IsRootNode { get; set; }
    public bool IsViewOnly { get; set; }
    public int MSParallels { get; set; } = 1;
    /// <summary>How many parents feed into this node (for DAG recalc)</summary>
    public List<(CalcTreeNode parent, string inputItemId)> ParentContributions { get; set; } = new();
}

public class MachineSummary
{
    public string MachineId { get; set; } = "";
    public string MachineName { get; set; } = "";
    public string MachineIconUrl { get; set; } = "";
    public double TotalCount { get; set; }
    public int TierLevel { get; set; }
    public string TierName { get; set; } = "";
    public string TierIconPath { get; set; } = "";
    public string TierCssClass { get; set; } = "";
}

public class RawResourceSummary
{
    public string ItemId { get; set; } = "";
    public string ItemName { get; set; } = "";
    public string ItemIconUrl { get; set; } = "";
    public double TotalPerSecond { get; set; }
}

public class EnergySummary
{
    public EnergyType Type { get; set; }
    public double TotalPerTick { get; set; }
}

public class CalculationResult
{
    public List<CalcTreeNode> RootNodes { get; set; } = new();
    public List<MachineSummary> Machines { get; set; } = new();
    public List<RawResourceSummary> RawResources { get; set; } = new();
    public List<EnergySummary> EnergySummaries { get; set; } = new();
}

public class CalculationService
{
    private readonly ItemService _itemService;
    private readonly RecipeService _recipeService;
    private readonly LocalizationService _loc;
    private int _nodeCounter;

    private string MakeNodeId(string itemId)
    {
        return $"nd_{itemId}_{_nodeCounter++}";
    }

    public CalculationService(ItemService itemService, RecipeService recipeService, LocalizationService loc)
    {
        _itemService = itemService;
        _recipeService = recipeService;
        _loc = loc;
    }

    public CalculationResult Calculate(string modpackId, List<ProductionRequest> requests,
        Dictionary<string, string>? savedChoices = null,
        Dictionary<string, int>? savedTiers = null,
        Dictionary<string, int>? savedCoils = null)
    {
        _nodeCounter = 0;
        var result = new CalculationResult();
        // Shared map: itemId -> existing node (for merging duplicates)
        var sharedMap = new Dictionary<string, CalcTreeNode>();

        foreach (var req in requests)
        {
            bool viewOnly = req.RateType == RateType.ViewOnly;
            double reqPerSec = viewOnly ? 0 : req.AmountPerSecond;

            // Check if this item already has a root node
            if (sharedMap.TryGetValue(req.Item.Id, out var existing))
            {
                existing.RequiredPerSecond += reqPerSec;
                existing.IsRootNode = true;
                if (!result.RootNodes.Contains(existing))
                    result.RootNodes.Add(existing);
                continue;
            }

            var node = BuildNode(modpackId, req.Item.Id, reqPerSec,
                new HashSet<string>(), viewOnly, savedChoices, savedTiers, savedCoils, sharedMap);
            if (node != null)
            {
                node.IsRootNode = true;
                result.RootNodes.Add(node);
            }
        }

        // Recalculate entire DAG properly
        RecalculateDAG(result.RootNodes);
        RebuildAllSummaries(result);
        return result;
    }

    private CalcTreeNode? BuildNode(string modpackId, string itemId, double reqPerSec,
        HashSet<string> ancestorChain, bool viewOnly,
        Dictionary<string, string>? choices,
        Dictionary<string, int>? tierChoices,
        Dictionary<string, int>? coilChoices,
        Dictionary<string, CalcTreeNode> sharedMap)
    {
        // If already built, reuse node (merge)
        if (sharedMap.TryGetValue(itemId, out var existing))
        {
            existing.RequiredPerSecond += reqPerSec;
            return existing;
        }

        // Cycle detection: if this item is an ancestor, skip entirely (no cycle node rendered)
        if (ancestorChain.Contains(itemId))
            return null;

        var item = _itemService.GetById(modpackId, itemId);
        if (item == null) return null;

        var node = new CalcTreeNode
        {
            ItemId = itemId,
            NodeId = MakeNodeId(itemId),
            ItemName = item.GetName(_loc.CurrentLanguage),
            ItemIconUrl = item.GetIconUrl(),
            RequiredPerSecond = reqPerSec,
            IsViewOnly = viewOnly
        };

        // Register in shared map BEFORE recursing to children
        sharedMap[itemId] = node;

        var allRecipes = _recipeService.FindAllRecipesForOutput(modpackId, itemId);
        if (allRecipes.Count == 0) return node;

        // Check saved choice
        if (choices != null && choices.TryGetValue(itemId, out var chosenId))
        {
            if (chosenId == "__storage__")
            {
                node.AvailableRecipes = allRecipes;
                SetAsStorage(node);
                return node;
            }
            var chosen = allRecipes.FirstOrDefault(r => r.Id == chosenId);
            if (chosen != null)
            {
                ApplyRecipeInternal(modpackId, node, chosen, ancestorChain, choices, tierChoices, coilChoices, sharedMap);
                return node;
            }
        }

        if (allRecipes.Count > 1)
        {
            node.NeedsRecipeSelection = true;
            node.AvailableRecipes = allRecipes;
            return node;
        }

        ApplyRecipeInternal(modpackId, node, allRecipes[0], ancestorChain, choices, tierChoices, coilChoices, sharedMap);
        return node;
    }

    private void ApplyRecipeInternal(string modpackId, CalcTreeNode node, Recipe recipe,
        HashSet<string> ancestorChain,
        Dictionary<string, string>? choices,
        Dictionary<string, int>? tierChoices,
        Dictionary<string, int>? coilChoices,
        Dictionary<string, CalcTreeNode> sharedMap)
    {
        node.Recipe = recipe;
        node.NeedsRecipeSelection = false;
        node.IsStorage = false;
        node.AvailableRecipes = _recipeService.FindAllRecipesForOutput(modpackId, node.ItemId);

        node.CurrentTierLevel = recipe.PrimaryEnergyType == EnergyType.EUt ? recipe.MinTierLevel : 0;
        node.CurrentCoilLevel = recipe.SupportsCoils ? recipe.MinCoilLevel : 1;

        if (tierChoices != null && tierChoices.TryGetValue(node.ItemId, out var savedTier))
            node.CurrentTierLevel = Math.Max(node.CurrentTierLevel, savedTier);
        if (coilChoices != null && coilChoices.TryGetValue(node.ItemId, out var savedCoil))
            node.CurrentCoilLevel = Math.Max(node.CurrentCoilLevel, savedCoil);

        ApplyOverclock(node);

        var newAncestors = new HashSet<string>(ancestorChain) { node.ItemId };
        node.Children.Clear();

        foreach (var input in recipe.Inputs)
        {
            var child = BuildNode(modpackId, input.ItemId, 0, // amount set later by DAG recalc
                newAncestors, node.IsViewOnly, choices, tierChoices, coilChoices, sharedMap);
            if (child != null && !node.Children.Contains(child))
                node.Children.Add(child);
        }
    }

    /// <summary>Called by RecipeTreeNode when user picks a recipe</summary>
    public void ApplyRecipe(string modpackId, CalcTreeNode node, Recipe recipe,
        HashSet<string>? visited = null, Dictionary<string, string>? choices = null)
    {
        visited ??= new HashSet<string>();
        node.Recipe = recipe;
        node.NeedsRecipeSelection = false;
        node.IsStorage = false;
        node.AvailableRecipes = _recipeService.FindAllRecipesForOutput(modpackId, node.ItemId);
        node.CurrentTierLevel = recipe.PrimaryEnergyType == EnergyType.EUt ? recipe.MinTierLevel : 0;
        node.CurrentCoilLevel = recipe.SupportsCoils ? recipe.MinCoilLevel : 1;
        ApplyOverclock(node);

        visited.Add(node.ItemId);
        node.Children.Clear();

        foreach (var input in recipe.Inputs)
        {
            if (visited.Contains(input.ItemId)) continue; // skip cycles
            var child = BuildTreeSimple(modpackId, input.ItemId, 0,
                new HashSet<string>(visited), node.IsViewOnly, choices);
            if (child != null) node.Children.Add(child);
        }
    }

    private CalcTreeNode? BuildTreeSimple(string modpackId, string itemId, double reqPerSec,
        HashSet<string> visited, bool viewOnly, Dictionary<string, string>? choices)
    {
        if (visited.Contains(itemId)) return null;

        var item = _itemService.GetById(modpackId, itemId);
        if (item == null) return null;

        var node = new CalcTreeNode
        {
            ItemId = itemId,
            NodeId = MakeNodeId(itemId),
            ItemName = item.GetName(_loc.CurrentLanguage),
            ItemIconUrl = item.GetIconUrl(),
            RequiredPerSecond = reqPerSec,
            IsViewOnly = viewOnly
        };

        var allRecipes = _recipeService.FindAllRecipesForOutput(modpackId, itemId);
        if (allRecipes.Count == 0) return node;

        if (allRecipes.Count > 1 && choices != null && choices.TryGetValue(itemId, out var chosenId))
        {
            if (chosenId == "__storage__")
            {
                node.AvailableRecipes = allRecipes;
                SetAsStorage(node);
                return node;
            }
            var chosen = allRecipes.FirstOrDefault(r => r.Id == chosenId);
            if (chosen != null)
            {
                ApplyRecipe(modpackId, node, chosen, visited, choices);
                return node;
            }
        }

        if (allRecipes.Count > 1)
        {
            node.NeedsRecipeSelection = true;
            node.AvailableRecipes = allRecipes;
            return node;
        }

        ApplyRecipe(modpackId, node, allRecipes[0], visited, choices);
        return node;
    }

    public void SetAsStorage(CalcTreeNode node)
    {
        node.Recipe = null;
        node.NeedsRecipeSelection = false;
        node.IsStorage = true;
        node.Children.Clear();
        node.MachineCount = 0;
        node.ActualEnergyPerTick = 0;
        node.ActualDurationTicks = 0;
    }

    // === DAG Recalculation using topological sort ===

    public void RecalculateDAG(List<CalcTreeNode> roots)
    {
        var all = FlattenTree(roots);
        if (all.Count == 0) return;

        // Build in-degree map
        var inDegree = new Dictionary<string, int>();
        var nodeById = new Dictionary<string, CalcTreeNode>();
        foreach (var n in all)
        {
            nodeById[n.NodeId] = n;
            if (!inDegree.ContainsKey(n.NodeId)) inDegree[n.NodeId] = 0;
        }
        foreach (var n in all)
            foreach (var c in n.Children)
                if (inDegree.ContainsKey(c.NodeId))
                    inDegree[c.NodeId]++;

        // Reset non-root RequiredPerSecond
        foreach (var n in all)
            if (!n.IsRootNode)
                n.RequiredPerSecond = 0;

        // Process in topological order (BFS)
        var queue = new Queue<CalcTreeNode>();
        foreach (var n in all.Where(n => inDegree.GetValueOrDefault(n.NodeId) == 0))
            queue.Enqueue(n);

        var processed = new HashSet<string>();
        int safety = all.Count * 2 + 10;
        while (queue.Count > 0 && safety-- > 0)
        {
            var n = queue.Dequeue();
            if (!processed.Add(n.NodeId)) continue;

            if (n.Recipe != null && !n.IsViewOnly)
            {
                ApplyOverclock(n);
                CalculateMachineCount(n);
                double ops = GetTotalOpsPerSecond(n);
                foreach (var c in n.Children)
                {
                    var inp = n.Recipe.Inputs.FirstOrDefault(i => i.ItemId == c.ItemId);
                    if (inp != null)
                        c.RequiredPerSecond += ops * inp.Amount;
                }
            }

            foreach (var c in n.Children)
            {
                if (!inDegree.ContainsKey(c.NodeId)) continue;
                inDegree[c.NodeId]--;
                if (inDegree[c.NodeId] <= 0 && !processed.Contains(c.NodeId))
                    queue.Enqueue(c);
            }
        }

        // Final pass: calculate machine counts for all nodes
        foreach (var n in all)
        {
            if (n.Recipe != null && !n.IsViewOnly)
            {
                ApplyOverclock(n);
                CalculateMachineCount(n);
            }
        }
    }

    public void RecalculateNode(string modpackId, CalcTreeNode n)
    {
        // For single-node changes (tier/coil change), recalculate entire DAG from roots
        // This is called from HandleChanged which already does full recalc
        if (n.Recipe == null || n.IsViewOnly) return;
        ApplyOverclock(n);
        CalculateMachineCount(n);
        double ops = GetTotalOpsPerSecond(n);
        var visited = new HashSet<string>();
        RecalcChildren(modpackId, n, ops, visited);
    }

    private void RecalcChildren(string modpackId, CalcTreeNode n, double parentOps, HashSet<string> visited)
    {
        if (!visited.Add(n.NodeId)) return;
        foreach (var c in n.Children)
        {
            if (n.Recipe == null) continue;
            var inp = n.Recipe.Inputs.FirstOrDefault(i => i.ItemId == c.ItemId);
            if (inp != null)
            {
                c.RequiredPerSecond = parentOps * inp.Amount;
                if (c.Recipe != null && !c.IsViewOnly)
                {
                    ApplyOverclock(c);
                    CalculateMachineCount(c);
                    double childOps = GetTotalOpsPerSecond(c);
                    RecalcChildren(modpackId, c, childOps, visited);
                }
            }
        }
    }

    public static Dictionary<string, string> CollectRecipeChoices(List<CalcTreeNode> roots)
    {
        var choices = new Dictionary<string, string>();
        var visited = new HashSet<string>();
        void Walk(CalcTreeNode n)
        {
            if (!visited.Add(n.NodeId)) return;
            if (n.IsStorage) choices[n.ItemId] = "__storage__";
            else if (n.Recipe != null) choices[n.ItemId] = n.Recipe.Id;
            foreach (var c in n.Children) Walk(c);
        }
        foreach (var r in roots) Walk(r);
        return choices;
    }

    public static Dictionary<string, int> CollectTierChoices(List<CalcTreeNode> roots)
    {
        var choices = new Dictionary<string, int>();
        var visited = new HashSet<string>();
        void Walk(CalcTreeNode n)
        {
            if (!visited.Add(n.NodeId)) return;
            if (n.Recipe != null && n.CurrentTierLevel > 0)
                choices[n.ItemId] = n.CurrentTierLevel;
            foreach (var c in n.Children) Walk(c);
        }
        foreach (var r in roots) Walk(r);
        return choices;
    }

    public static Dictionary<string, int> CollectCoilChoices(List<CalcTreeNode> roots)
    {
        var choices = new Dictionary<string, int>();
        var visited = new HashSet<string>();
        void Walk(CalcTreeNode n)
        {
            if (!visited.Add(n.NodeId)) return;
            if (n.Recipe != null && n.Recipe.SupportsCoils)
                choices[n.ItemId] = n.CurrentCoilLevel;
            foreach (var c in n.Children) Walk(c);
        }
        foreach (var r in roots) Walk(r);
        return choices;
    }

    public static void ApplyOverclock(CalcTreeNode node)
    {
        if (node.Recipe == null) return;
        int oc = node.Recipe.PrimaryEnergyType == EnergyType.EUt
            ? Math.Max(0, node.CurrentTierLevel - node.Recipe.MinTierLevel) : 0;
        double dur = node.Recipe.DurationTicks, en = node.Recipe.EnergyPerTick;
        node.MSParallels = 1;
        switch (node.Recipe.CoilMachineType)
        {
            case CoilMachineType.ElectricBlastFurnace: ApplyEBF(node, dur, en, oc); return;
            case CoilMachineType.MultiSmelter: ApplyMS(node, en); return;
            case CoilMachineType.PyrolyseOven: ApplyPO(node, dur, en, oc); return;
            case CoilMachineType.CrackingUnit: ApplyCU(node, dur, en, oc); return;
            default:
                node.ActualEnergyPerTick = en * Math.Pow(4, oc);
                node.ActualDurationTicks = dur / Math.Pow(2, oc);
                return;
        }
    }

    private static void ApplyEBF(CalcTreeNode n, double dur, double en, int oc)
    {
        int ci = Math.Clamp(n.CurrentCoilLevel - 1, 0, 7);
        int t = CoilTier.AllCoils[ci].Temperature + Math.Max(0, n.CurrentTierLevel - 3) * 100;
        int ex = Math.Max(0, t - n.Recipe!.MinTemperature);
        double speedBonus = Math.Min(Math.Pow(2, ex / 1800), Math.Pow(4, oc));
        n.ActualDurationTicks = dur / Math.Pow(2, oc) / speedBonus;
        n.ActualEnergyPerTick = en * Math.Pow(4, oc) * Math.Pow(0.95, ex / 900);
    }
    private static void ApplyMS(CalcTreeNode n, double en)
    {
        int ci = Math.Clamp(n.CurrentCoilLevel - 1, 0, 7);
        n.MSParallels = CoilTier.MSParallels[ci];
        n.ActualDurationTicks = n.Recipe!.DurationTicks;
        n.ActualEnergyPerTick = en * CoilTier.MSEnergyMult[ci];
    }
    private static void ApplyPO(CalcTreeNode n, double dur, double en, int oc)
    {
        int ci = Math.Clamp(n.CurrentCoilLevel - 1, 0, 7);
        n.ActualDurationTicks = dur / Math.Pow(2, oc) / CoilTier.POSpeedMult[ci];
        n.ActualEnergyPerTick = en * Math.Pow(4, oc);
    }
    private static void ApplyCU(CalcTreeNode n, double dur, double en, int oc)
    {
        int ci = Math.Clamp(n.CurrentCoilLevel - 1, 0, 7);
        n.ActualDurationTicks = dur / Math.Pow(2, oc);
        n.ActualEnergyPerTick = en * Math.Pow(4, oc) * CoilTier.CUEnergyMult[ci];
    }

    private static void CalculateMachineCount(CalcTreeNode n)
    {
        if (n.Recipe == null) return;
        var o = n.Recipe.Outputs.FirstOrDefault(x => x.ItemId == n.ItemId);
        if (o == null) { n.MachineCount = 0; return; }
        double d = n.ActualDurationTicks / 20.0;
        double ips = (d > 0 ? 1.0 / d : 0) * o.Amount * n.MSParallels;
        n.MachineCount = ips > 0 ? n.RequiredPerSecond / ips : 0;
    }

    private static double GetTotalOpsPerSecond(CalcTreeNode n)
    {
        if (n.Recipe == null) return 0;
        double d = n.ActualDurationTicks / 20.0;
        return d > 0 ? n.MachineCount / d * n.MSParallels : 0;
    }

    public void RefreshAllNames(string modpackId, List<CalcTreeNode> nodes)
    {
        var visited = new HashSet<string>();
        void Walk(List<CalcTreeNode> list)
        {
            foreach (var n in list)
            {
                if (!visited.Add(n.NodeId)) continue;
                var item = _itemService.GetById(modpackId, n.ItemId);
                if (item != null) n.ItemName = item.GetName(_loc.CurrentLanguage);
                Walk(n.Children);
            }
        }
        Walk(nodes);
    }

    public static List<CalcTreeNode> FlattenTree(List<CalcTreeNode> roots)
    {
        var l = new List<CalcTreeNode>();
        var seen = new HashSet<string>();
        void W(CalcTreeNode n)
        {
            if (!seen.Add(n.NodeId)) return;
            l.Add(n);
            foreach (var c in n.Children) W(c);
        }
        foreach (var r in roots) W(r);
        return l;
    }

    // === LAYOUT: proper top-down tree with subtree width calculation ===

    public static Dictionary<string, double[]> ComputeInitialLayout(List<CalcTreeNode> roots)
    {
        var pos = new Dictionary<string, double[]>();
        if (roots.Count == 0) return pos;

        const int nodeW = 270;
        const int hGap = 40;
        const int vGap = 120;

        // Calculate subtree widths (with DAG-safe visited set)
        var widthCache = new Dictionary<string, double>();
        double CalcWidth(CalcTreeNode n, HashSet<string> v)
        {
            if (widthCache.ContainsKey(n.NodeId)) return widthCache[n.NodeId];
            if (!v.Add(n.NodeId)) return nodeW;
            if (n.Children.Count == 0) { widthCache[n.NodeId] = nodeW; return nodeW; }
            double childrenW = n.Children.Sum(c => CalcWidth(c, v)) + (n.Children.Count - 1) * hGap;
            double w = Math.Max(nodeW, childrenW);
            widthCache[n.NodeId] = w;
            return w;
        }

        // Calculate total width of all root trees
        foreach (var r in roots) CalcWidth(r, new HashSet<string>());

        double totalRootW = roots.Sum(r => widthCache.GetValueOrDefault(r.NodeId, nodeW)) + (roots.Count - 1) * hGap * 2;
        double startX = 100;

        // Layout each root tree
        var placed = new HashSet<string>();
        void Layout(CalcTreeNode n, double cx, double y)
        {
            if (!placed.Add(n.NodeId)) return;
            double x = cx - nodeW / 2.0;
            pos[n.NodeId] = new[] { Math.Round(x / 20.0) * 20, Math.Round(y / 20.0) * 20 };

            if (n.Children.Count == 0) return;

            double childrenTotalW = n.Children.Sum(c => widthCache.GetValueOrDefault(c.NodeId, nodeW))
                                    + (n.Children.Count - 1) * hGap;
            double childStartX = cx - childrenTotalW / 2.0;

            foreach (var c in n.Children)
            {
                double cw = widthCache.GetValueOrDefault(c.NodeId, nodeW);
                double ccx = childStartX + cw / 2.0;
                Layout(c, ccx, y + vGap);
                childStartX += cw + hGap;
            }
        }

        double rx = startX;
        foreach (var root in roots)
        {
            double rw = widthCache.GetValueOrDefault(root.NodeId, nodeW);
            Layout(root, rx + rw / 2.0, 100);
            rx += rw + hGap * 2;
        }

        return pos;
    }

    public List<ArrowConnection> BuildArrowConnections(string modpackId, List<CalcTreeNode> roots)
    {
        var conns = new List<ArrowConnection>();
        var visited = new HashSet<string>();
        foreach (var r in roots) CollectArrows(r, conns, visited);
        return conns;
    }

    private void CollectArrows(CalcTreeNode par, List<ArrowConnection> conns, HashSet<string> visited)
    {
        if (!visited.Add(par.NodeId)) return;
        int tt = par.Children.Count;
        for (int i = 0; i < par.Children.Count; i++)
        {
            var ch = par.Children[i];
            conns.Add(new ArrowConnection
            {
                FromNode = ch.NodeId,
                ToNode = par.NodeId,
                FromSide = "top",
                ToSide = "bottom",
                FromIndex = 0,
                FromTotal = 1,
                ToIndex = i,
                ToTotal = tt,
                Items = new() { new ArrowItemInfo { ItemId = ch.ItemId, IconUrl = ch.ItemIconUrl } }
            });
            CollectArrows(ch, conns, visited);
        }
    }

    public void RebuildAllSummaries(CalculationResult result)
    {
        var mc = new Dictionary<string, MachineSummary>();
        var rr = new Dictionary<string, RawResourceSummary>();
        var et = new Dictionary<EnergyType, double>();
        var visited = new HashSet<string>();
        foreach (var r in result.RootNodes) CollectSummary(r, mc, rr, et, visited);
        result.Machines = mc.Values.OrderByDescending(m => m.TotalCount).ToList();
        result.RawResources = rr.Values.OrderByDescending(r => r.TotalPerSecond).ToList();
        result.EnergySummaries = et.Select(kv => new EnergySummary { Type = kv.Key, TotalPerTick = kv.Value }).ToList();
    }

    public (List<MachineSummary>, List<RawResourceSummary>, List<EnergySummary>) RebuildSummaries(List<CalcTreeNode> roots)
    {
        var r = new CalculationResult { RootNodes = roots };
        RebuildAllSummaries(r);
        return (r.Machines, r.RawResources, r.EnergySummaries);
    }

    private void CollectSummary(CalcTreeNode n, Dictionary<string, MachineSummary> mc,
        Dictionary<string, RawResourceSummary> rr, Dictionary<EnergyType, double> et, HashSet<string> visited)
    {
        if (!visited.Add(n.NodeId)) return;
        if (n.IsViewOnly) return;
        if (n.IsRawResource || n.IsStorage)
        {
            if (rr.ContainsKey(n.ItemId)) rr[n.ItemId].TotalPerSecond += n.RequiredPerSecond;
            else rr[n.ItemId] = new RawResourceSummary
            {
                ItemId = n.ItemId,
                ItemName = n.ItemName,
                ItemIconUrl = n.ItemIconUrl,
                TotalPerSecond = n.RequiredPerSecond
            };
        }
        else if (n.Recipe != null)
        {
            var tier = n.Recipe.PrimaryEnergyType == EnergyType.EUt ? VoltageTier.GetByLevel(n.CurrentTierLevel) : null;
            var key = $"{n.Recipe.MachineId}_{tier?.Name ?? ""}";
            if (mc.ContainsKey(key)) mc[key].TotalCount += n.MachineCount;
            else mc[key] = new MachineSummary
            {
                MachineId = n.Recipe.MachineId,
                MachineName = n.Recipe.GetMachineName(_loc.CurrentLanguage),
                MachineIconUrl = n.Recipe.GetMachineIconUrl(),
                TotalCount = n.MachineCount,
                TierLevel = n.CurrentTierLevel,
                TierName = tier?.Name ?? "",
                TierIconPath = tier?.IconPath ?? "",
                TierCssClass = tier?.CssClass ?? ""
            };
            double te = n.ActualEnergyPerTick * Math.Ceiling(n.MachineCount);
            et[n.Recipe.PrimaryEnergyType] = et.GetValueOrDefault(n.Recipe.PrimaryEnergyType) + te;
            if (n.Recipe.UsesHeatUnit)
                et[EnergyType.HUt] = et.GetValueOrDefault(EnergyType.HUt) + n.Recipe.HeatPerTick * Math.Ceiling(n.MachineCount);
        }
        foreach (var c in n.Children) CollectSummary(c, mc, rr, et, visited);
    }
}