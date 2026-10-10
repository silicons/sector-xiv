namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * Memory is a collection of data stored on an invocation by the user program.
 * <br />
 * <br />
 * Arcanima operates with key-value memory. Programs must declare their memory keys in advance,
 * which allows an inherent optimization: memory keys are stored as references, and the program can use those
 * references instead of string comaprisons.
 * <br />
 * <br />
 * Types must also be declared in advance, allowing the program to be statically analyzed.
 * This is mostly for user convenience, but may allow for future optimizations.
 */
public sealed class Memory
{
    private Dictionary<MemoryKey, MemoryValue> _memory = new();
}
