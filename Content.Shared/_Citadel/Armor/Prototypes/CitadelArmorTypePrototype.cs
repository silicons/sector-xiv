using Content.Shared._Citadel.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Shared._Citadel.Armor.Prototypes;

/// <summary>
/// A single armor type. Damage types are not the same as armor types; for example,
/// 'piercing' is an armor type, 'brute' is a damage type.
/// </summary>
[Prototype] [CitadelPrototype]
public sealed partial class CitadelArmorTypePrototype : ICitadelPrototype
{
    [DataField("model", required: true)]
#warning serde
    public ArmorModel Modelling = ArmorModel.Flat;

    [DataField(required: true)]
    private LocId Name { get; set; }

    [ViewVariables(VVAccess.ReadOnly)]
    public string LocalizedName => Loc.GetString(Name);

    [IdDataField]
    public string ID { get; private set; } = default!;
}
