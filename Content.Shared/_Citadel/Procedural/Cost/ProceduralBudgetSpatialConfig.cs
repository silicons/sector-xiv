namespace Content.Shared._Citadel.Procedural.Cost;

/// <summary>
/// Configures a budget to be over an area.
/// <br />
/// <br />
/// This is important because you don't want to do 100 cost for, say, 100x100 tiles,
/// and then do the same 100 cost for 10_000 x 10_000 tiles.
/// <br />
/// <br />
/// This config type scales to volume.
/// </summary>
public sealed class ProceduralBudgetSpatialConfig<TKey> : AbstractProceduralBudgetConfig<TKey>
    where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Input boxes are treated as a 2D area with dimension of meters.
    /// <br />
    /// <br />
    /// This is how much budget to add per meter.
    /// </summary>
    public Dictionary<TKey, double> BudgetsPerSquareMeter = new();

    /// <summary>
    /// Create a budget for a given area.
    /// </summary>
    /// <param name="bounds">Box2; units should be meters / tiles.</param>
    /// <returns></returns>
    public ProceduralBudget<TKey> CreateBudget(Box2 bounds)
    {
        var budget = CreateBaseBudget();
#warning impl
    }

    public ProceduralBudget<TKey> CreateBudget(IEnumerable<Box2> bounds)
    {
        var budget = CreateBaseBudget();
#warning impl
    }

    private double GetBudgetForArea(TKey key, Box2 bounds)
    {
#warning impl
    }

    private double GetBudgetForArea(TKey key, double squareMeters)
    {
#warning impl
    }
}
