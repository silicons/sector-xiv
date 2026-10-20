using Content.Shared._Citadel.Armor.Systems;
using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Armor;

[DataDefinition] [Serializable] [NetSerializable]
public sealed partial class ArmorSpecifier() : IEquatable<ArmorSpecifier>,
    IRobustCloneable<ArmorSpecifier>
{
    /// <summary>
    /// Amount of damage that is deflected by the armor if the attack is not over this.
    /// <br />
    /// <br />
    /// Only used when ArmorModel is set to Dynamic for an armor type.
    /// </summary>
    public float Deflect;

    /// <summary>
    /// Multiplier for damage reduction. For example, a value of 0.5 would reduce incoming damage by 50%.
    /// </summary>
    public float Multiplier = 1.0f;

    /// <summary>
    /// Amount of damage that is absorbed by the armor before being applied to the wearer. For example, a value of 5 would
    /// absorb 5 points of damage before applying the rest to the wearer.
    /// </summary>
    public float Soak;

    /// <summary>
    /// Armor tier; a rough measure of how 'hard' the armor is.
    /// <br />
    /// <br />
    /// Only used when ArmorModel is set to Dynamic for an armor type.
    /// <br />
    /// Armor tier will both determine the chances of an attack
    /// penetrating the armor, as well as modulate the true multiplier.
    /// <br />
    /// <br />
    /// Armor tier does not impact soak or deflect values.
    /// <br />
    /// <br />
    /// Default tier is 0.
    /// </summary>
    public float Tier;

    public bool Equals(ArmorSpecifier? other)
    {
        if (other is null)
            return false;

        const float tolerance = SharedCitadelArmorSystem.ArmorPrecision;

        return Math.Abs(Deflect - other.Deflect) < tolerance &&
               Math.Abs(Multiplier - other.Multiplier) < tolerance &&
               Math.Abs(Soak - other.Soak) < tolerance &&
               Math.Abs(Tier - other.Tier) < tolerance;
    }

    public ArmorSpecifier Clone()
    {
        throw new NotImplementedException();
    }
}
