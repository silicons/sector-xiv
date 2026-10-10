namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A carrier is a single 'executing program'.
 *
 * What makes Arcanima different from say, Hexcasting (minecraft fans rejoice),
 * is a spell / program doesn't have a single 'source'; programs when invoked
 * start (usually) with one (or sometimes more) carriers, and those carriers
 * are what executes.
 *
 * Carriers share the same Invocation, which tracks their global state.
 */
public sealed class Carrier(Invocation invocation)
{
    public
        Invocation Invocation { get; } = invocation;

    /**
     * <summary>
     * Whether the carrier is paused.
     * <br />
     * <br />
     * Paused carriers will not evaluate their tick-loop, but reactions still work.
     * </summary>
     */
    public bool Paused { get; set; } = false;
}
