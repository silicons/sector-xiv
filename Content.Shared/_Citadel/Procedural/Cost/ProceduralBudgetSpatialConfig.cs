namespace Content.Shared._Citadel.Procedural.Cost;

/// <summary>
/// Configures a budget to be over an area.
/// <br />
/// <br />
/// This is important because you don't want to do 100 cost for, say, 100x100 tiles,
/// and then do the same 100 cost for 10_000 x 10_000 tiles.
/// <br />
/// <br />
/// This config type scales to area.
/// </summary>
public sealed class ProceduralBudgetSpatialConfig<TKey> : AbstractProceduralBudgetConfig<TKey>
    where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Input boxes are treated as a 2D area with dimension of meters.
    /// <br />
    /// <br />
    /// This is how much budget to add per square meter.
    /// </summary>
    public Dictionary<TKey, double> BudgetsPerSquareMeter = new();

    /// <summary>
    /// Create a budget for a given area.
    /// </summary>
    /// <param name="bounds">Box2; units should be meters / tiles.</param>
    /// <returns></returns>
    public ProceduralBudget<TKey> CreateBudget(Box2 bounds)
    {
        return CreateBudgetForArea(GetArea(bounds));
    }

    /// <summary>
    /// Overlaps will not be deduped.
    /// </summary>
    public ProceduralBudget<TKey> CreateBudget(IEnumerable<Box2> bounds)
    {
        ArgumentNullException.ThrowIfNull(bounds);

        var squareMeters = 0.0;
        foreach (var box in bounds)
        {
            squareMeters += GetArea(box);
        }

        return CreateBudgetForArea(squareMeters);
    }

    private ProceduralBudget<TKey> CreateBudgetForArea(double squareMeters)
    {
        if (!double.IsFinite(squareMeters))
            throw new ArgumentOutOfRangeException(nameof(squareMeters), "Area must be finite.");

        var budget = CreateBaseBudget();
        foreach (var (key, rate) in BudgetsPerSquareMeter)
        {
            if (!double.IsFinite(rate) || rate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(BudgetsPerSquareMeter),
                    "Budget rates must be finite and nonnegative.");
            }

            // prevent wraparound, force checked
            var scaled = checked((long)Math.Floor(rate * squareMeters));
            budget.Budget.TryGetValue(key, out var remaining);
            budget.Budget[key] = checked(remaining + scaled);
        }

        return budget;
    }

    private static double GetArea(Box2 bounds)
    {
        var width = Math.Abs((double)bounds.Right - bounds.Left);
        var height = Math.Abs((double)bounds.Top - bounds.Bottom);
        var area = width * height;
        if (!double.IsFinite(area))
            throw new ArgumentOutOfRangeException(nameof(bounds), "Box area must be finite.");

        return area;
    }
}
