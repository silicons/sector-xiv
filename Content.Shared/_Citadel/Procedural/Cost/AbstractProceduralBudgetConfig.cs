namespace Content.Shared._Citadel.Procedural.Cost;

public abstract class AbstractProceduralBudgetConfig<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Static cost to add for each key
    /// </summary>
    public readonly Dictionary<TKey, long> StaticBudgets = new();

    protected ProceduralBudget<TKey> CreateBaseBudget()
    {
#warning impl
    }
}
