namespace Content.Shared._Citadel.Procedural.Cost;

public sealed class ProceduralBudget<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Costs left for each key
    /// </summary>
    public readonly Dictionary<TKey, long> Budget = new();

    /// <summary>
    /// Returns the budget left for a key, or zero if it is absent.
    /// </summary>
    public long GetKey(TKey key)
    {
        return Budget.GetValueOrDefault(key);
    }

    /// <summary>
    /// Consumes the amount if available; returns true / false.
    /// </summary>
    public bool TryConsumeKey(TKey key, long amount)
    {
        if (!HasKey(key, amount))
            return false;

        ConsumeKey(key, amount);
        return true;
    }

    /// <summary>
    /// Consumes for a key. This can result in the budget becoming negative.
    /// </summary>
    public void ConsumeKey(TKey key, long amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        Budget[key] = checked(GetKey(key) - amount);
    }

    /// <summary>
    /// Checks whether the key has at least the requested amount left.
    /// </summary>
    public bool HasKey(TKey key, long amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        return GetKey(key) >= amount;
    }

    /// <summary>
    /// Checks whether we have at least this cost.
    /// </summary>
    public bool HasCosts(ProceduralCosts<TKey> costs)
    {
        ArgumentNullException.ThrowIfNull(costs);

        var affordable = true;
        foreach (var (key, cost) in costs.Costs)
        {
            if (cost < 0)
                throw new ArgumentOutOfRangeException(nameof(costs), "Costs must be nonnegative.");

            if (!HasKey(key, cost))
                affordable = false;
        }

        return affordable;
    }

    /// <summary>
    /// Consumes all keys in cost if we have all of them. Returns true / false.
    /// </summary>
    public bool TryConsumeCosts(ProceduralCosts<TKey> costs)
    {
        if (!HasCosts(costs))
            return false;

        ConsumeCosts(costs);
        return true;
    }

    /// <summary>
    /// Consumes cost forcefully. Budgets can become negative from this!
    /// </summary>
    public void ConsumeCosts(ProceduralCosts<TKey> costs)
    {
        ArgumentNullException.ThrowIfNull(costs);

        // We still validate just in case.
        foreach (var (key, cost) in costs.Costs)
        {
            if (cost < 0)
                throw new ArgumentOutOfRangeException(nameof(costs), "Costs must be nonnegative.");

            _ = checked(GetKey(key) - cost);
        }

        foreach (var (key, cost) in costs.Costs)
        {
            ConsumeKey(key, cost);
        }
    }
}
