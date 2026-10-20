namespace Content.Shared._Citadel.Damage.Systems;

/// <summary>
/// This handles...
/// </summary>
public abstract class SharedCitadelDamageSystem : CitadelSystem
{
    /// <summary>
    /// Damage is rounded to this value.
    /// </summary>
    public const float DamagePrecision = 0.001f;

    /// <inheritdoc />
    public override void Initialize()
    {
    }
}
