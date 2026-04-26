namespace TFGCalculator.Services;

using TFGCalculator.Models;

public class AnvilService
{
    private readonly ItemService _itemService;
    private readonly LocalizationService _loc;

    // ModpackId можно считать глобальным (один на сайт), либо брать из параметров
    public string DefaultModpackId { get; set; } = "tfg-modern";

    public AnvilService(ItemService itemService, LocalizationService loc)
    {
        _itemService = itemService;
        _loc = loc;
    }

    private readonly List<AnvilRecipe> _recipes = new()
    {

        new AnvilRecipe {
            Id = "high_carbon_steel_ingot",
            InputItemId = "pig_iron_ingot",
            OutputItemId = "high_carbon_steel_ingot",
            TargetValue = 54,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Hit },
                new() { RequiredAction = AnvilActionType.Hit },
                new() { RequiredAction = AnvilActionType.Hit }
            }
        },
        new AnvilRecipe {
            Id = "bronze_scythe_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_scythe_head",
            TargetValue = 86,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "bronze_chisel_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_chisel_head",
            TargetValue = 80,
            EndConstraints = new() {
                new() { AnyHit = true },
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "bronze_axe_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_axe_head",
            TargetValue = 98,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Upset }
            }
        },
        new AnvilRecipe {
            Id = "bronze_saw_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_saw_head",
            TargetValue = 80,
            EndConstraints = new() {
                new() { AnyHit = true },
                new() { AnyHit = true }
            }
        },
        new AnvilRecipe {
            Id = "bronze_screwdriver_tip",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_screwdriver_tip",
            TargetValue = 69,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Draw },
                new() { AnyHit = true },
                new() { AnyHit = true }
            }
        },
        new AnvilRecipe {
            Id = "bronze_tong_part",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_tong_part",
            TargetValue = 79,
            EndConstraints = new() {
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Draw },
                new() { RequiredAction = AnvilActionType.Bend }
            }
        },
        new AnvilRecipe {
            Id = "bronze_propick_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_propick_head",
            TargetValue = 83,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Draw },
                new() { RequiredAction = AnvilActionType.Bend }
            }
        },
        new AnvilRecipe {
            Id = "bronze_nugget",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_nugget",
            TargetValue = 50,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Punch }
            }
        },
        new AnvilRecipe {
            Id = "bars_bronze",
            InputItemId = "bronze_ingot",
            OutputItemId = "bars_bronze",
            TargetValue = 78,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Upset },
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Punch }
            }
        },
        new AnvilRecipe {
            Id = "bronze_knife_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_knife_head",
            TargetValue = 67,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "bronze_file_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_file_head",
            TargetValue = 98,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Upset },
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Punch }
            }
        },
        new AnvilRecipe {
            Id = "bronze_hammer_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_hammer_head",
            TargetValue = 73,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Shrink }
            }
        },
        new AnvilRecipe {
            Id = "bronze_pickaxe_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_pickaxe_head",
            TargetValue = 83,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "small_bronze_gear",
            InputItemId = "bronze_ingot",
            OutputItemId = "small_bronze_gear",
            TargetValue = 92,
            EndConstraints = new() {
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Shrink },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "bronze_rod",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_rod",
            TargetValue = 91,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "bronze_shovel_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_shovel_head",
            TargetValue = 69,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { AnyHit = true }
            }
        },
        new AnvilRecipe {
            Id = "bronze_hoe_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_hoe_head",
            TargetValue = 54,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Bend }
            }
        },
        new AnvilRecipe {
            Id = "bronze_mattock_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_mattock_head",
            TargetValue = 51,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Bend }
            }
        },
        new AnvilRecipe {
            Id = "chain_bronze",
            InputItemId = "bronze_ingot",
            OutputItemId = "chain_bronze",
            TargetValue = 54,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Draw },
                new() { AnyHit = true },
                new() { AnyHit = true }
            }
        },
        new AnvilRecipe {
            Id = "bronze_butchery_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_butchery_head",
            TargetValue = 41,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Punch },
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Bend }
            }
        },
        new AnvilRecipe {
            Id = "unfinished_lamp_bronze",
            InputItemId = "bronze_ingot",
            OutputItemId = "unfinished_lamp_bronze",
            TargetValue = 99,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },
        new AnvilRecipe {
            Id = "bronze_fish_hook",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_fish_hook",
            TargetValue = 88,
            EndConstraints = new() {
                new() { RequiredAction = AnvilActionType.Bend },
                new() { RequiredAction = AnvilActionType.Draw },
                new() { AnyHit = true }
            }
        },
        new AnvilRecipe {
            Id = "bronze_javelin_head",
            InputItemId = "bronze_ingot",
            OutputItemId = "bronze_javelin_head",
            TargetValue = 98,
            EndConstraints = new() {
                new() { AnyHit = true },
                new() { AnyHit = true },
                new() { RequiredAction = AnvilActionType.Draw }
            }
        },

        

        // Пример:
        // new AnvilRecipe
        // {
        // Id = "pickaxe_head",
        // InputItemId = "copper_ingot",
        // OutputItemId = "pickaxe_head_copper",
        // TargetValue = 40,
        // EndConstraints = new()
        //     {
        //     new() { RequiredAction = AnvilActionType.Punch },
        //     new() { AnyHit = true }
        //     }
        // },
    };

    public List<AnvilRecipe> GetAll() => _recipes;
    public List<AnvilRecipe> Search(string modpackId, string q)
    {
        if (string.IsNullOrWhiteSpace(q)) return _recipes;
        return _recipes.Where(r =>
        {
            var inIt = _itemService.GetById(modpackId, r.InputItemId);
            var outIt = _itemService.GetById(modpackId, r.OutputItemId);
            string inName = inIt?.GetName(_loc.CurrentLanguage) ?? r.InputItemId;
            string outName = outIt?.GetName(_loc.CurrentLanguage) ?? r.OutputItemId;
            return r.Id.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                   inName.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                   outName.Contains(q, StringComparison.OrdinalIgnoreCase);
        }).ToList();
    }

    /// <summary>Find minimum sequence of actions from 0 to target matching end constraints. BFS.</summary>
    public List<AnvilActionInfo>? Solve(AnvilRecipe recipe)
    {
        int target = recipe.TargetValue;
        var constraints = recipe.EndConstraints;
        int maxConstraints = constraints.Count; // 0-3

        // State: (value, last3 actions encoded)
        // Actions encoded as indices 0-7, last3 as tuple
        var actions = AnvilActions.All;
        int actionCount = actions.Count;

        // BFS state: (value, last action indices stack)
        // Encode state: value * 512 + last3 encoded (8^3 = 512)
        const int MIN_VAL = -30, MAX_VAL = 175;
        int range = MAX_VAL - MIN_VAL + 1;
        int stateSize = range * 512;

        var visited = new bool[stateSize];
        var parent = new int[stateSize];
        var parentAction = new int[stateSize];
        Array.Fill(parent, -1);

        int EncodeL3(int a2, int a1, int a0) => a2 * 64 + a1 * 8 + a0; // each 0-7
        (int a2, int a1, int a0) DecodeL3(int v) => (v / 64, (v / 8) % 8, v % 8);
        int EncodeState(int val, int l3) => (val - MIN_VAL) * 512 + l3;

        // Initial state: value=0, no last actions (use 0 as placeholder)
        int initL3 = EncodeL3(0, 0, 0);
        int initState = EncodeState(0, initL3);
        visited[initState] = true;

        var queue = new Queue<(int state, int steps, int val, int l3)>();
        queue.Enqueue((initState, 0, 0, initL3));

        while (queue.Count > 0)
        {
            var (state, steps, val, l3) = queue.Dequeue();
            var (la2, la1, la0) = DecodeL3(l3);

            // Check if goal
            if (val == target && steps >= maxConstraints)
            {
                // Check end constraints
                bool ok = true;
                var lastActions = new[] { la0, la1, la2 }; // index 0 = most recent
                for (int ci = 0; ci < maxConstraints && ci < steps; ci++)
                {
                    if (!constraints[ci].Matches(actions[lastActions[ci]].Type)) { ok = false; break; }
                }
                if (ok)
                {
                    // Reconstruct path
                    var path = new List<AnvilActionInfo>();
                    int s = state;
                    while (parent[s] >= 0)
                    {
                        path.Add(actions[parentAction[s]]);
                        s = parent[s];
                    }
                    path.Reverse();
                    return path;
                }
            }

            // Expand
            for (int ai = 0; ai < actionCount; ai++)
            {
                int newVal = val + actions[ai].Value;
                if (newVal < MIN_VAL || newVal > MAX_VAL) continue;
                int newL3 = EncodeL3(la1, la0, ai);
                int newState = EncodeState(newVal, newL3);
                if (newState < 0 || newState >= stateSize) continue;
                if (visited[newState]) continue;
                visited[newState] = true;
                parent[newState] = state;
                parentAction[newState] = ai;
                queue.Enqueue((newState, steps + 1, newVal, newL3));
            }
        }

        return null; // No solution found
    }
}