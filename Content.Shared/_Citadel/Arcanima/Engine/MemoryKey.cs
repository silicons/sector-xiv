namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * Memory key. They're declared per program. Their references are used as map keys.
 *
 * This means that once a program is 'compiled', it should never be modified, as otherwise
 * you can desync the memory keys between the program and active invocations.
 */
public sealed class MemoryKey(string name, MemoryType type)
{
    public string Name { get; } = name;
    public MemoryType Type { get; } = type;
}
