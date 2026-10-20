using Content.Shared._Citadel.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Shared._Citadel.Damage.Prototypes;

/// <summary>
/// Represents a damage type.
/// <br />
/// <br />
/// Citadel's damage type handling is more complicated than SS14 mainline's.
/// <br /> These are automatically converted to SS14 damage types for compatibility with the rest of the engine.
/// </summary>
[Prototype] [CitadelPrototype]
public sealed partial class CitadelDamageTypePrototype : ICitadelPrototype
{
    [DataField(required: true)]
    private LocId Name { get; set; }

    [ViewVariables(VVAccess.ReadOnly)]
    public string LocalizedName => Loc.GetString(Name);


    [IdDataField]
    public string ID { get; private set; } = default!;
}
