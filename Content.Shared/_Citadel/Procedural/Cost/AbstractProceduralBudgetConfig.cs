namespace Content.Shared._Citadel.Procedural.Cost;

public abstract class AbstractProceduralBudgetConfig<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
{
    /// <summary>
    /// Static cost to add for each key
    /// <br />
    /// <br />
    /// Must be positive to pass validation.
    /// </summary>
    public readonly Dictionary<TKey, long> StaticBudgets = new();

    protected ProceduralBudget<TKey> CreateBaseBudget()
    {
        var budget = new ProceduralBudget<TKey>();
        foreach (var (key, amount) in StaticBudgets)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(StaticBudgets), "Budgets must be nonnegative.");

            budget.Budget.Add(key, amount);
        }

        return budget;
    }
}
