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
public sealed class ProceduralBudgetSpatialConfig<TKey> : ProceduralBudgetConfig<TKey>
    where TKey : IEquatable<TKey>, IComparable<TKey>
{
    public ProceduralBudget<TKey> CreateBudget(Box2 bounds)
    {
        var budget = CreateBaseBudget();
#warning impl
    }
}
