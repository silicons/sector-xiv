using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Damage;

[DataDefinition] [Serializable] [NetSerializable]
public sealed partial class DamageSpecifier : IEquatable<DamageSpecifier>, IRobustCloneable<DamageSpecifier>
{
}
