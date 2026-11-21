namespace Content.Shared._Citadel.Procedural.Cost;

public sealed class ProceduralCosts<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Costs for each key
    /// </summary>
    public readonly Dictionary<TKey, long> Costs = new();
}
