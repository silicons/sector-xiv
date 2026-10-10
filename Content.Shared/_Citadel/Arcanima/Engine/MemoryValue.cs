namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A value in memory.
 * <br />
 * <br />
 * For performance and memory-usage measurement reasons, these are structs.
 * <br />
 * They should be around 9 bytes in size, as
 * <br />
 * <br />
 * Values may have the following types;
 * <li>double - `Number` is a double</li>
 * <li>string - 'Linked' is a String</li>
 * <li>list - 'Linked' </li>
 */
public struct MemoryValue
{
    private double Number = 0.0;
    private object? Linked = null;
}
