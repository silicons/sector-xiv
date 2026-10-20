using Content.Shared._Citadel.Armor.Prototypes;
using Content.Shared._Citadel.Damage.Prototypes;

namespace Content.Shared._Citadel.Damage;

/// <summary>
/// A single instance of damage, which can be applied to an entity.
/// <br />
/// <br />
/// Despite being in the Damage system / module, DamageInstance is what Armor
/// and certain other things are actually intercepting.
/// <br />
/// <br />
/// The combat system pretty much does;
/// <li>Click / Action</li>
/// <li>Attack</li>
/// <li>Defense - Specific (Projectile, Melee, etc)</li>
/// <li>
/// Defense - Generic (Damage Instance) &lt;== Armor lives here!
/// </li>
/// <li>Deal Damage Event - End</li>
/// <br />
/// <br />
/// DamageInstance is where the first half (specific defense, attack handling, hit detection and registration, etc)
/// hands off to general Defense calls and then finally hands off to the health system of
/// something.
/// </summary>
public struct DamageInstance
{
    public float Amount;

    /// <summary>
    /// The damage type of the damage instance.
    /// </summary>
    public CitadelDamageTypePrototype DamageType;

    /// <summary>
    /// The tier of the damage instance to be matched against armor
    /// if the armor type being checked is set to Dynamic.
    /// <br />
    /// <br />
    /// This is optional; legacy damage instances will not have this set.
    /// </summary>
    public float? Tier;

    /// <summary>
    /// The armor type to be checked against.
    /// </summary>
    public CitadelArmorTypePrototype ArmorType;

    /// <summary>
    /// Flags for the damage instance.
    /// </summary>
    public DamageFlags Flags;
}
