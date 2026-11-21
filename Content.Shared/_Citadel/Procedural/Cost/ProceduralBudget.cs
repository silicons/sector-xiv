namespace Content.Shared._Citadel.Procedural.Cost;

public sealed class ProceduralBudget<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Costs left for each key
    /// </summary>
    public readonly Dictionary<TKey, long> Budget = new();


}
