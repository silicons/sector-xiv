namespace Content.Shared._Citadel.Procedural.Cost;

public abstract class ProceduralBudgetConfig<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Static cost to add for each key
    /// </summary>
    public readonly Dictionary<TKey, long> StaticBudget = new();

    protected ProceduralBudget<TKey> CreateBaseBudget()
    {
#warning impl
    }
}
