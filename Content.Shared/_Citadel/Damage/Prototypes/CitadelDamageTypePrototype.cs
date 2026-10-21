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

    /// <summary>
    /// Dictionary of other damage types to apply in addition to this type.
    /// Useful for split damage type (inherent multiplier 0.0, 0.5 to brute, 0.5 to burn, etc.)
    /// <br />
    /// <br />
    /// Note that damage systems should only allow one layer of rebind, for performance and stability reasons.
    /// </summary>
    public Dictionary<ProtoId<CitadelDamageTypePrototype>, float>? RebindMultipliers { get; private set; }

    /// <summary>
    /// Multiplier to use when applying this damage type. Used to allow
    /// rebind-only damage types to completely convert themselves.
    /// </summary>
    public float Multiplier { get; private set; } = 1.0f;

    /// <summary>
    /// Synchronization holder for prototype updates.
    /// </summary>
    public CitadelPrototypeSync Sync { get; } = new();

    /// <summary>
    /// Primary ID for the prototype.
    /// </summary>
    [IdDataField]
    public string ID { get; private set; } = default!;
}
