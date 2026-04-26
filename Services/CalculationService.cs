namespace TFGCalculator.Services;

using TFGCalculator.Models;

public class CalcTreeNode
{
    public string ItemId { get; set; } = "";
    public string ItemName { get; set; } = "";
    public string ItemIconUrl { get; set; } = "";
    public string ItemType { get; set; } = "";
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

    /// <summary>Спрос на каждый выходной предмет этой ноды (для мульти-выходных рецептов)</summary>
    public Dictionary<string, double> OutputDemand { get; set; } = new();

    /// <summary>Все выходные предметы рецепта, закреплённые за этой нодой (для отображения)</summary>
    public List<string> OutputItemIds { get; set; } = new();

    /// <summary>Суффикс варианта (для нескольких корней одного предмета с разными рецептами)</summary>
    public string VariantSuffix { get; set; } = "";
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

    // Stable nodeId: one node per itemId in merged DAG
    private static string MakeNodeId(string itemId) => $"nd_{itemId}";

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
        var result = new CalculationResult();
        var sharedMap = new Dictionary<string, CalcTreeNode>();
        var recipeMap = new Dictionary<string, CalcTreeNode>();

        // Count variant index per itemId for duplicate root requests (fix #3)
        var variantCounter = new Dictionary<string, int>();

        foreach (var req in requests)
        {
            bool viewOnly = req.RateType == RateType.ViewOnly;
            double reqPerSec = viewOnly ? 0 : req.AmountPerSecond;

            int curIdx = variantCounter.GetValueOrDefault(req.Item.Id, 0);
            variantCounter[req.Item.Id] = curIdx + 1;

            if (curIdx == 0)
            {
                // Primary root — normal path with merging
                if (sharedMap.TryGetValue(req.Item.Id, out var existing))
                {
                    AddDemand(existing, req.Item.Id, reqPerSec);
                    existing.IsRootNode = true;
                    if (!result.RootNodes.Contains(existing)) result.RootNodes.Add(existing);
                    continue;
                }
                var node = BuildNode(modpackId, req.Item.Id, reqPerSec,
                    new HashSet<string>(), viewOnly, savedChoices, savedTiers, savedCoils,
                    sharedMap, recipeMap, variantSuffix: "");
                if (node != null) { node.IsRootNode = true; result.RootNodes.Add(node); }
            }
            else
            {
                // Variant root — independent subtree (separate maps & nodeId suffix)
                var suffix = $"_v{curIdx}";
                var vShared = new Dictionary<string, CalcTreeNode>();
                var vRecipe = new Dictionary<string, CalcTreeNode>();
                var node = BuildNode(modpackId, req.Item.Id, reqPerSec,
                    new HashSet<string>(), viewOnly, savedChoices, savedTiers, savedCoils,
                    vShared, vRecipe, variantSuffix: suffix);
                if (node != null) { node.IsRootNode = true; result.RootNodes.Add(node); }
            }
        }

        RecalculateDAG(result.RootNodes);
        RebuildAllSummaries(result);
        return result;
    }

    private static void AddDemand(CalcTreeNode n, string itemId, double amount)
    {
        if (amount == 0) return;
        n.OutputDemand[itemId] = n.OutputDemand.GetValueOrDefault(itemId, 0) + amount;
        if (itemId == n.ItemId) n.RequiredPerSecond += amount;
    }

    private CalcTreeNode? BuildNode(string modpackId, string itemId, double reqPerSec,
    HashSet<string> ancestorChain, bool viewOnly,
    Dictionary<string, string>? choices,
    Dictionary<string, int>? tierChoices,
    Dictionary<string, int>? coilChoices,
    Dictionary<string, CalcTreeNode> sharedMap,
    Dictionary<string, CalcTreeNode> recipeMap,
    string variantSuffix = "")
    {
        // Merge by itemId within this subtree
        if (sharedMap.TryGetValue(itemId, out var existing))
        {
            AddDemand(existing, itemId, reqPerSec);
            return existing;
        }
        if (ancestorChain.Contains(itemId)) return null;

        var item = _itemService.GetById(modpackId, itemId);
        var allRecipes = item != null
            ? _recipeService.FindAllRecipesForOutput(modpackId, itemId)
            : new List<Recipe>();

        // Determine chosen recipe
        Recipe? chosen = null;
        bool isStorage = false;
        bool needsSelection = false;

        // Choice lookup — try variant-specific key first, then plain itemId
        string? chId = null;
        if (choices != null)
        {
            if (!string.IsNullOrEmpty(variantSuffix) && choices.TryGetValue(itemId + variantSuffix, out var v1)) chId = v1;
            else if (choices.TryGetValue(itemId, out var v0)) chId = v0;
        }
        if (chId == "__storage__") isStorage = true;
        else if (!string.IsNullOrEmpty(chId)) chosen = allRecipes.FirstOrDefault(r => r.Id == chId);

        if (!isStorage && chosen == null)
        {
            if (allRecipes.Count == 1) chosen = allRecipes[0];
            else if (allRecipes.Count > 1) needsSelection = true;
        }

        // === RECIPE MERGE: if this recipe already has a node, reuse it ===
        if (chosen != null && recipeMap.TryGetValue(chosen.Id, out var recNode))
        {
            sharedMap[itemId] = recNode;
            AddDemand(recNode, itemId, reqPerSec);
            if (!recNode.OutputItemIds.Contains(itemId))
                recNode.OutputItemIds.Add(itemId);
            return recNode;
        }

        // Create new node
        var node = new CalcTreeNode
        {
            ItemId = itemId,
            NodeId = $"nd_{itemId}{variantSuffix}",
            VariantSuffix = variantSuffix,
            ItemName = item?.GetName(_loc.CurrentLanguage) ?? itemId,
            ItemIconUrl = item?.GetIconUrl() ?? "",
            ItemType = item?.Type ?? "",
            RequiredPerSecond = reqPerSec,
            IsViewOnly = viewOnly
        };
        node.OutputDemand[itemId] = reqPerSec;
        node.OutputItemIds.Add(itemId);
        sharedMap[itemId] = node;

        if (item == null)
        {
            Console.Error.WriteLine($"[CalculationService] Item not found: {itemId}");
            return node;
        }
        if (allRecipes.Count == 0) return node;

        node.AvailableRecipes = allRecipes;

        if (isStorage) { SetAsStorage(node); return node; }
        if (needsSelection) { node.NeedsRecipeSelection = true; return node; }
        if (chosen == null) return node;

        recipeMap[chosen.Id] = node;
        // Also register the other outputs of this recipe to reuse the same node
        foreach (var o in chosen.Outputs)
        {
            if (o.ItemId != itemId && !sharedMap.ContainsKey(o.ItemId))
                sharedMap[o.ItemId] = node;
            if (!node.OutputItemIds.Contains(o.ItemId))
                node.OutputItemIds.Add(o.ItemId);
        }

        ApplyRecipeInternal(modpackId, node, chosen, ancestorChain,
            choices, tierChoices, coilChoices, sharedMap, recipeMap, variantSuffix);
        return node;
    }

    private void ApplyRecipeInternal(string modpackId, CalcTreeNode node, Recipe recipe,
        HashSet<string> ancestorChain,
        Dictionary<string, string>? choices,
        Dictionary<string, int>? tierChoices,
        Dictionary<string, int>? coilChoices,
        Dictionary<string, CalcTreeNode> sharedMap,
        Dictionary<string, CalcTreeNode> recipeMap,
        string variantSuffix)
    {
        node.Recipe = recipe;
        node.NeedsRecipeSelection = false;
        node.IsStorage = false;
        node.AvailableRecipes = _recipeService.FindAllRecipesForOutput(modpackId, node.ItemId);

        node.CurrentTierLevel = recipe.PrimaryEnergyType == EnergyType.EUt ? recipe.MinTierLevel : 0;
        node.CurrentCoilLevel = recipe.SupportsCoils ? recipe.MinCoilLevel : 1;

        var tierKey = node.ItemId + variantSuffix;
        if (tierChoices != null && (tierChoices.TryGetValue(tierKey, out var st) || tierChoices.TryGetValue(node.ItemId, out st)))
            node.CurrentTierLevel = Math.Max(node.CurrentTierLevel, st);
        var coilKey = node.ItemId + variantSuffix;
        if (coilChoices != null && (coilChoices.TryGetValue(coilKey, out var sc) || coilChoices.TryGetValue(node.ItemId, out sc)))
            node.CurrentCoilLevel = Math.Max(node.CurrentCoilLevel, sc);

        ApplyOverclock(node);

        var newAncestors = new HashSet<string>(ancestorChain) { node.ItemId };
        node.Children.Clear();

        foreach (var input in recipe.Inputs)
        {
            if (string.IsNullOrEmpty(input.ItemId)) continue;
            var child = BuildNode(modpackId, input.ItemId, 0,
                newAncestors, node.IsViewOnly, choices, tierChoices, coilChoices,
                sharedMap, recipeMap, variantSuffix);
            if (child != null && !node.Children.Contains(child))
                node.Children.Add(child);
        }
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

    // === DAG Recalculation ===
    public void RecalculateDAG(List<CalcTreeNode> roots)
    {
        var all = FlattenTree(roots);
        if (all.Count == 0) return;

        var inDegree = new Dictionary<string, int>();
        foreach (var n in all) inDegree[n.NodeId] = 0;
        foreach (var n in all)
            foreach (var c in n.Children)
                if (inDegree.ContainsKey(c.NodeId))
                    inDegree[c.NodeId]++;

        // Reset non-root demand
        foreach (var n in all)
        {
            if (!n.IsRootNode)
            {
                n.RequiredPerSecond = 0;
                n.OutputDemand.Clear();
            }
        }

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
                foreach (var inp in n.Recipe.Inputs)
                {
                    // Child may contain this input either as its primary item or as an alias output
                    var child = n.Children.FirstOrDefault(c =>
                        c.ItemId == inp.ItemId || c.OutputItemIds.Contains(inp.ItemId));
                    if (child == null) continue;
                    double amt = ops * inp.Amount;
                    if (inp.ItemId == child.ItemId) child.RequiredPerSecond += amt;
                    child.OutputDemand[inp.ItemId] = child.OutputDemand.GetValueOrDefault(inp.ItemId, 0) + amt;
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

        foreach (var n in all)
        {
            if (n.Recipe != null && !n.IsViewOnly)
            {
                ApplyOverclock(n);
                CalculateMachineCount(n);
            }
        }
    }

    // === Choice collection ===
    public static Dictionary<string, string> CollectRecipeChoices(List<CalcTreeNode> roots)
    {
        var choices = new Dictionary<string, string>();
        var visited = new HashSet<string>();
        void Walk(CalcTreeNode n)
        {
            if (!visited.Add(n.NodeId)) return;
            var key = n.ItemId + n.VariantSuffix;
            if (n.IsStorage) choices[key] = "__storage__";
            else if (n.Recipe != null) choices[key] = n.Recipe.Id;
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
            var key = n.ItemId + n.VariantSuffix;
            if (n.Recipe != null && n.CurrentTierLevel > 0) choices[key] = n.CurrentTierLevel;
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
            var key = n.ItemId + n.VariantSuffix;
            if (n.Recipe != null && n.Recipe.SupportsCoils) choices[key] = n.CurrentCoilLevel;
            foreach (var c in n.Children) Walk(c);
        }
        foreach (var r in roots) Walk(r);
        return choices;
    }

    // === Overclock ===
    public static void ApplyOverclock(CalcTreeNode node)
    {
        if (node.Recipe == null) return;
        if (node.Recipe.IsCraftingTable)
        {
            // Верстак: энергия и тики равны 0, дюрация = 1 тик (для расчёта количества крафтов)
            node.ActualEnergyPerTick = 0;
            node.ActualDurationTicks = 1;  // 1 тик = мгновенно, но считать скорость
            node.MSParallels = 1;
            return;
        }
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
                node.ActualDurationTicks = dur / Math.Pow(2, oc); return;
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
        if (n.Recipe == null) { n.MachineCount = 0; return; }
        double dSec = n.ActualDurationTicks / 20.0;
        if (dSec <= 0) { n.MachineCount = 0; return; }
        double maxM = 0;
        foreach (var o in n.Recipe.Outputs)
        {
            double demand = n.OutputDemand.GetValueOrDefault(o.ItemId, 0);
            if (demand <= 0 || o.Amount <= 0) continue;
            double ips = o.Amount * n.MSParallels / dSec;
            double m = ips > 0 ? demand / ips : 0;
            if (m > maxM) maxM = m;
        }
        n.MachineCount = maxM;
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
                if (item != null) { n.ItemName = item.GetName(_loc.CurrentLanguage); n.ItemType = item.Type; }
                Walk(n.Children);
            }
        }
        Walk(nodes);
    }

    public static List<CalcTreeNode> FlattenTree(List<CalcTreeNode> roots)
    {
        var l = new List<CalcTreeNode>();
        var seen = new HashSet<string>();
        void W(CalcTreeNode n) { if (!seen.Add(n.NodeId)) return; l.Add(n); foreach (var c in n.Children) W(c); }
        foreach (var r in roots) W(r);
        return l;
    }

    // === LAYOUT: layered DAG (Sugiyama-lite) ===
    public static Dictionary<string, double[]> ComputeInitialLayout(List<CalcTreeNode> roots)
    {
        var pos = new Dictionary<string, double[]>();
        var all = FlattenTree(roots);
        if (all.Count == 0) return pos;

        // Визуально мягкий вариант (как было до последнего ужесточения)
        const int NODE_W = 320;
        const int NODE_H = 240;
        const int H_GAP = 80;
        const int V_GAP = 140;                 // чистый зазор между слоями (для стрелок)
        const int LAYER_STEP = NODE_H + V_GAP; // полный шаг слоёв по Y = 380
        const double GRID = 20;

        // 1. Глубина (longest path)
        var depth = new Dictionary<string, int>();
        foreach (var n in all) depth[n.NodeId] = 0;
        bool changed = true;
        int maxIter = all.Count * all.Count + 10;
        while (changed && maxIter-- > 0)
        {
            changed = false;
            foreach (var n in all)
                foreach (var c in n.Children)
                {
                    int d = depth[n.NodeId] + 1;
                    if (d > depth[c.NodeId]) { depth[c.NodeId] = d; changed = true; }
                }
        }

        // 2. Группы по слоям
        var byLayer = new SortedDictionary<int, List<CalcTreeNode>>();
        foreach (var n in all)
        {
            int d = depth[n.NodeId];
            if (!byLayer.ContainsKey(d)) byLayer[d] = new();
            byLayer[d].Add(n);
        }

        // 3. Упорядочивание + позиции по X
        var xPos = new Dictionary<string, double>();
        var layerKeys = byLayer.Keys.ToList();
        foreach (var layerKey in layerKeys)
        {
            var nodes = byLayer[layerKey];
            if (layerKey == 0)
            {
                double x = 100;
                foreach (var n in nodes) { xPos[n.NodeId] = x; x += NODE_W + H_GAP; }
            }
            else
            {
                var parentCenter = new Dictionary<string, double>();
                foreach (var n in nodes)
                {
                    var parents = all.Where(p => p.Children.Contains(n)).ToList();
                    parentCenter[n.NodeId] = parents.Count > 0
                        ? parents.Average(p => xPos.GetValueOrDefault(p.NodeId, 0) + NODE_W / 2.0)
                        : 0;
                }
                var sortedNodes = nodes.OrderBy(n => parentCenter.GetValueOrDefault(n.NodeId, 0)).ToList();
                byLayer[layerKey] = sortedNodes;
                double x = 100;
                for (int i = 0; i < sortedNodes.Count; i++)
                {
                    double target = parentCenter.GetValueOrDefault(sortedNodes[i].NodeId, x) - NODE_W / 2.0;
                    double actual = Math.Max(x, target);
                    xPos[sortedNodes[i].NodeId] = actual;
                    x = actual + NODE_W + H_GAP;
                }
            }
        }

        // 4. Центрирование родителей над детьми + разрешение перекрытий
        for (int pass = 0; pass < 3; pass++)
        {
            foreach (var kv in byLayer)
                foreach (var n in kv.Value)
                {
                    if (n.Children.Count == 0) continue;
                    double childCenter = n.Children.Average(c => xPos.GetValueOrDefault(c.NodeId, 0) + NODE_W / 2.0);
                    xPos[n.NodeId] = childCenter - NODE_W / 2.0;
                }
            foreach (var kv in byLayer)
            {
                var nodes = kv.Value.OrderBy(n => xPos.GetValueOrDefault(n.NodeId, 0)).ToList();
                for (int i = 1; i < nodes.Count; i++)
                {
                    double minX = xPos[nodes[i - 1].NodeId] + NODE_W + H_GAP;
                    if (xPos[nodes[i].NodeId] < minX) xPos[nodes[i].NodeId] = minX;
                }
            }
        }

        // 5. Нормализация + запись (использует NODE_H через LAYER_STEP)
        double minXVal = xPos.Values.Min();
        double shift = 200 - minXVal;
        foreach (var kv in byLayer)
        {
            double layerY = 200 + kv.Key * LAYER_STEP;   // ← NODE_H используется
            foreach (var n in kv.Value)
            {
                double x = xPos[n.NodeId] + shift;
                pos[n.NodeId] = new[] { Math.Round(x / GRID) * GRID, Math.Round(layerY / GRID) * GRID };
            }
        }
        return pos;
    }

    // === Arrows ===
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
                Items = new() { new ArrowItemInfo {
                  ItemId = ch.ItemId,
                  IconUrl = ch.ItemIconUrl,
                  ItemName = ch.ItemName
                } }
            });
            CollectArrows(ch, conns, visited);
        }
    }

    // === Summaries ===
    public void RebuildAllSummaries(CalculationResult result)
    {
        var mc = new Dictionary<string, MachineSummary>();
        var rr = new Dictionary<string, RawResourceSummary>();
        var et = new Dictionary<EnergyType, double>();
        var visited = new HashSet<string>();
        foreach (var r in result.RootNodes) CS(r, mc, rr, et, visited);
        result.Machines = mc.Values.OrderByDescending(m => m.TotalCount).ToList();
        result.RawResources = rr.Values.OrderByDescending(r => r.TotalPerSecond).ToList();
        result.EnergySummaries = et.Select(kv => new EnergySummary { Type = kv.Key, TotalPerTick = kv.Value }).ToList();
    }

    public (List<MachineSummary>, List<RawResourceSummary>, List<EnergySummary>) RebuildSummaries(List<CalcTreeNode> roots)
    {
        var r = new CalculationResult { RootNodes = roots }; RebuildAllSummaries(r);
        return (r.Machines, r.RawResources, r.EnergySummaries);
    }

    private void CS(CalcTreeNode n, Dictionary<string, MachineSummary> mc,
        Dictionary<string, RawResourceSummary> rr, Dictionary<EnergyType, double> et, HashSet<string> visited)
    {
        if (!visited.Add(n.NodeId)) return;
        if (n.IsViewOnly) return;
        if (n.IsRawResource || n.IsStorage)
        {
            if (rr.ContainsKey(n.ItemId)) rr[n.ItemId].TotalPerSecond += n.RequiredPerSecond;
            else rr[n.ItemId] = new RawResourceSummary { ItemId = n.ItemId, ItemName = n.ItemName, ItemIconUrl = n.ItemIconUrl, TotalPerSecond = n.RequiredPerSecond };
        }
        else if (n.Recipe != null)
        {
            VoltageTier? tier = n.Recipe.PrimaryEnergyType == EnergyType.EUt ? VoltageTier.GetByLevel(n.CurrentTierLevel) : null;
            var key = $"{n.Recipe.MachineId}_{tier?.Name ?? ""}";
            if (mc.ContainsKey(key)) mc[key].TotalCount += n.MachineCount;
            else mc[key] = new MachineSummary
            {
                MachineId = n.Recipe.MachineId,
                MachineName = n.Recipe.GetMachineName(_loc.CurrentLanguage),
                MachineIconUrl = n.Recipe.GetTieredMachineIconUrl(n.CurrentTierLevel),
                TotalCount = n.MachineCount,
                TierLevel = n.CurrentTierLevel,
                TierName = tier?.Name ?? "",
                TierIconPath = tier?.IconPath ?? "",
                TierCssClass = tier?.CssClass ?? ""
            };
            if (!n.Recipe.IsCraftingTable)
            {
                double te = n.ActualEnergyPerTick * Math.Ceiling(n.MachineCount);
                et[n.Recipe.PrimaryEnergyType] = et.GetValueOrDefault(n.Recipe.PrimaryEnergyType) + te;
                if (n.Recipe.UsesHeatUnit)
                    et[EnergyType.HUt] = et.GetValueOrDefault(EnergyType.HUt) + n.Recipe.HeatPerTick * Math.Ceiling(n.MachineCount);
            }
        }
        foreach (var c in n.Children) CS(c, mc, rr, et, visited);
    }
}