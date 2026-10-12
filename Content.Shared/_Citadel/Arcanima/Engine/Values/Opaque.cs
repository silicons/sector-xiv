using Content.Shared._Citadel.Arcanima.Engine.Interfaces;

namespace Content.Shared._Citadel.Arcanima.Engine.Values;

/**
 * An opaque value may be used by the frontend to store arbitrary data that is not interpreted by the engine.
 * <br />
 * <br />
 * Frontends may use this to store things like entity references; the Arcanima engine is entirely
 * agnostic to how frontends identify entities, because magically doing so (all puns intended)
 * via EntityUid would be overpowered as hell for players to have access to.
 * <br />
 * <br />
 * Payloads must implement IOpaqueData for copying and memory measurement.
 */
public sealed class Opaque(IOpaqueData value) : ValueBase
{
    public IOpaqueData Value { get; set; } = value;

    public override Opaque Copy()
    {
        return new Opaque((IOpaqueData)Value.Copy());
    }

    public override ulong GetMemoryUnits()
    {
        return 1;
    }
}
