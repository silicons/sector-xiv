using Content.Shared._Citadel.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.Array;

namespace Content.Shared._Citadel.Worldgen.Prototypes;

/// <summary>
/// A submap layer to be used during worldgen.
/// </summary>
[Prototype]
public sealed partial class SubmapLayerPrototype : ICitadelPrototype, IInheritingPrototype
{
    /// <inheritdoc />
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <inheritdoc />
    [ParentDataField(typeof(AbstractPrototypeIdArraySerializer<SubmapLayerPrototype>))]
    public string[]? Parents { get; private set; }

    /// <inheritdoc />
    [NeverPushInheritance]
    [AbstractDataField]
    public bool Abstract { get; private set; }
}
