using Content.Shared._Citadel.Arcanima.Engine.Interfaces;

namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A value.
 * <br />
 * <br />
 * Arcanima's engine uses typed values, and this is the base class for all of them.
 * <br />
 * This is made in a way to be friendly to transform into discriminated unions in the future,
 * so hopefully someday this can all be structs for speed.
 */
public abstract class ValueBase : IMemoryMeasurable
{
    /**
     * Measures this in memory units.
     * <br />
     * <br />
     * You should assume that this value can and will change from under you.
     * <br />
     * As a rule of thumb, every 8 bytes is 1 memory unit.
     */
    public abstract ulong GetMemoryUnits();

    /// <summary>
    /// Returns an independent copy, including any nested mutable values.
    /// </summary>
    public abstract ValueBase Copy();
}
