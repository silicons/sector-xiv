using System.Runtime.CompilerServices;

namespace Content.Shared._Citadel.Random;

/// <summary>
/// Citadel 64-bit PRNG interface. Derived samples assume uniformly distributed output from <see cref="Next" />.
/// Generic samplers are provided by <see cref="CitadelRandomExtensions" /> so callers can inline them.
/// </summary>
public interface ICitadelRandom : ICloneable
{
    object ICloneable.Clone()
    {
        return Clone();
    }

    /// <summary>
    /// Returns the next 64-bit unsigned integer from the PRNG.
    /// </summary>
    ulong Next();

    /// <summary>
    /// Copies the current state into an independent generator with the same subsequent sequence.
    /// </summary>
    new ICitadelRandom Clone();

    /// <summary>
    /// Returns a uniformly spaced double in [0, 1), using 53 random bits.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    double NextDouble()
    {
        return (Next() >> 11) * (1.0 / (1UL << 53));
    }
}
