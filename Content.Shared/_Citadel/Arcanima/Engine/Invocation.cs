namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * An invocation is a shared instance between all its Carrier's.
 */
public sealed class Invocation
{
#warning Invocation execution and resource accounting are not implemented.
    private List<CarrierThread> _carriers = new();

    /**
     * Running average of compute units used per tick.
     */
    private double computeUnitsProcessAverage = 0;

    /**
     * Compute units consumed since the start of the processing tick
     * <br />
     * <br />
     * This is updated over time to throttle invocations as a whole (not just carriers!)
     * when they're too expensive.
     * <br />
     * <br />
     * At time of writing, we don't care about other invocations from the same player, mostly because
     * 'player' isn't an IC concept, 'invocation' is. If people are obnoxious, we may consider
     * throttling by mind (soul) so you can't cheese it.
     */
    private ulong computeUnitsSinceLastProcess = 0;

    /**
     * Lifetime remaining.
     * <br />
     * <br />
     * Lifetime stops you from making something that lasts forever, is too annoying, or is bad for physics.
     * <br />
     * <br />
     * While memory and compute units can throttle the program itself, programs with moving carriers
     * are still going to mess with the physics engine.
     */
    private ulong lifetimeRemaining = 0;

    /**
     * Current memory units consumed.
     * <br />
     * <br />
     * This is what limits things from OOMing the server
     * or otherwise spreading far too much.
     * <br />
     * <br />
     * This is the only 'hard' limit that generally will detonate someone's program, because otherwise
     * you can make a program that does nothing and spreads and it'll be
     * <i>pretty</i>
     * but also
     * insanely annoying.
     */
    private ulong memoryUnits = 0;
}
