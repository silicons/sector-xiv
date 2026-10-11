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
 * Values must be quickly memory-measurable via IMemoryMeasurable.
 * <br />
 * <br />
 * Values must implement IMemoryCopyable.
 */
public sealed class Opaque : ValueBase
{
    public Opaque(object value)
    {
        if (value is not IMemoryMeasurable)
            throw new ArgumentException($"Opaque value must be {nameof(IMemoryMeasurable)}");
        if (value is not IMemoryCopyable)
            throw new ArgumentException($"Opaque value must be {nameof(IMemoryCopyable)}");
        Value = value;
    }

    /// <summary>
    /// Private constructor doesn't bother checking interfaces again.
    /// </summary>
    /// <param name="other"></param>
    private Opaque(Opaque other)
    {
        Value = other.Value;
    }

    public object Value { get; set; }

    public override Opaque Copy()
    {
        return new Opaque(Value);
    }

    public override ulong GetMemoryUnits()
    {
        return 1;
    }
}
