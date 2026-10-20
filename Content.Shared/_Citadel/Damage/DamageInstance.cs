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
    public CitadelDamageTypePrototype DamageType;
}
