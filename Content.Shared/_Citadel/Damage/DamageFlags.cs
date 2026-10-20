namespace Content.Shared._Citadel.Damage;

/// <summary>
/// Quick flags that are sent with damage to indicate special properties of the damage.
/// </summary>
public enum DamageFlags : ulong
{
    None = 0,

    /// <summary>
    /// Damage is sharp for purposes of medical code.
    /// <br />
    /// <br />
    /// Things like knives and other things that cut do this.
    /// </summary>
    Sharp = 1UL << 0,

    /// <summary>
    /// Damage is highly piercing.
    /// <br />
    /// <br />
    /// Things like bullets and other things that do deep punctures apply this.
    /// </summary>
    Pierce = 1UL << 1,

    /// <summary>
    /// Damage is shredding for purposes of medical code.
    /// <br />
    /// <br />
    /// Things like chainsaws, claws, and other things that make very messy wounds apply this.
    /// </summary>
    Shred = 1UL << 2,

    /// <summary>
    /// Damage is ablative for purposes of medical code.
    /// <br />
    /// <br />
    /// Things like lasers and other things that impart so much energy it should
    /// effectively blow a crater do this.
    /// </summary>
    Ablating = 1UL << 3,

    /// <summary>
    /// Damage is from an edged / bladed weapon.
    /// <br />
    /// <br />
    /// Things like swords and knives being used to slice do this.
    /// </summary>
    Edge = 1UL << 4,

    /// <summary>
    /// Damage is coming from inside.
    /// <br />
    /// <br />
    /// Damage is coming from inside the body / entity, do not apply armor and whatnot.
    /// </summary>
    Internal = 1UL << 5,

    /// <summary>
    /// Damage is gradual.
    /// <br />
    /// <br />
    /// Damage is slowly applied. Do not do bone break triggers at all and similar.
    /// </summary>
    Gradual = 1UL << 6,

    /// <summary>
    /// Request the damage be redirected to another body part (or part of an entity)
    /// if the targeted part doesn't exist.
    /// </summary>
    RequestRedirectIfInvalidZone = 1UL << 61,

    /// <summary>
    /// Requests that armor may blunt dangerous damage flags if this is set.
    /// </summary>
    RequestArmorBlunting = 1UL << 62,

    /// <summary>
    /// Request armor randomization be used.
    /// <br />
    /// <br />
    /// Armor randomization isn't used unless this flag is set.
    /// <br />
    /// This is to prevent armor randomization from messing with unit tests
    /// and otherwise deterministic scenarios.
    /// </summary>
    RequestArmorRandomization = 1UL << 63,

    /// <summary>
    /// Flags that are blunted by armor on a successful block.
    /// </summary>
    FlagsBluntedByArmor = Sharp | Pierce | Shred | Ablating | Edge,

    /// <summary>
    /// Flags that can be specified on a specifier via YAML / configuration / varedit.
    /// </summary>
    SpecifierFlagsPositive = Sharp | Pierce | Shred | Ablating | Edge | Internal | Gradual,

    /// <summary>
    /// Flags that can be specified on a specifier **TO BE REMOVED** despite them being generally handled automatically.
    /// </summary>
    SpecifierFlagsNegative = RequestArmorBlunting | RequestArmorRandomization | RequestRedirectIfInvalidZone,
}
