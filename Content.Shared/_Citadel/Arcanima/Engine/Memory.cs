using Content.Shared._Citadel.Arcanima.Engine.Values;

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
 */
public sealed class Memory
{
    private Dictionary<MemoryKey, ValueRef> _memory = new();
}
