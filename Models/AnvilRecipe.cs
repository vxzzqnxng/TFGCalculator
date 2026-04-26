namespace TFGCalculator.Models;

public class AnvilEndConstraint
{
    public AnvilActionType? RequiredAction { get; set; }
    public bool AnyHit { get; set; }

    public bool Matches(AnvilActionType action)
    {
        if (AnyHit) return AnvilActions.IsAnyHit(action);
        if (RequiredAction == null) return true;
        return RequiredAction.Value == action;
    }
}

public class AnvilRecipe
{
    public string Id { get; set; } = "";
    public string InputItemId { get; set; } = "";
    public string OutputItemId { get; set; } = "";
    public int TargetValue { get; set; }
    public List<AnvilEndConstraint> EndConstraints { get; set; } = new();
}