namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A stack of memory values.
 * <br />
 * <br />
 * This is the core execution context for a Carrier.
 * <br />
 * Internally, this supports indexed access.
 */
public sealed class Stack
{
    private List<MemoryValue> _values = new();

}
