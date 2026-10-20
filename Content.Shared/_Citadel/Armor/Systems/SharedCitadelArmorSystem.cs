namespace Content.Shared._Citadel.Armor.Systems;

/// <summary>
/// This handles...
/// </summary>
public abstract class SharedCitadelArmorSystem : CitadelSystem
{
    /// <summary>
    /// Armor is rounded to this value.
    /// </summary>
    public const float ArmorPrecision = 0.01f;

    /// <inheritdoc />
    public override void Initialize()
    {
    }
}
