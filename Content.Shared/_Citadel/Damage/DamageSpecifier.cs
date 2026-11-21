using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Damage;

[DataDefinition] [Serializable] [NetSerializable]
public sealed partial class DamageSpecifier : IEquatable<DamageSpecifier>, IRobustCloneable<DamageSpecifier>
{
    public float Amount;

    public DamageFlags FlagsAdded;
    public DamageFlags FlagsRemoved;

    public bool Equals(DamageSpecifier? other)
    {
        return other is not null
            && Amount.Equals(other.Amount)
            && FlagsAdded == other.FlagsAdded
            && FlagsRemoved == other.FlagsRemoved;
    }

    public DamageSpecifier Clone()
    {
        return new DamageSpecifier
        {
            Amount = Amount,
            FlagsAdded = FlagsAdded,
            FlagsRemoved = FlagsRemoved,
        };
    }
}
