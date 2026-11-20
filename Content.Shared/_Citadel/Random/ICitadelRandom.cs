using System.Runtime.CompilerServices;

namespace Content.Shared._Citadel.Random;

/// <summary>
/// Citadel 64-bit PRNG interface. Derived samples assume uniformly distributed output from <see cref="Next" />.
/// Integer methods without bounds cover the full range of their return type.
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

    /// <summary>Returns a uniformly spaced float in [0, 1), using 24 random bits.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    float NextFloat()
    {
        return (Next() >> 40) * (1.0f / (1U << 24));
    }

    /// <summary>Returns an integer over the full signed 32-bit range.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    int NextI32()
    {
        return unchecked((int)(Next() >> 32));
    }

    /// <summary>Returns an integer over the full unsigned 32-bit range.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    uint NextU32()
    {
        return (uint)(Next() >> 32);
    }

    /// <summary>Returns an integer over the full signed 64-bit range.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    long NextI64()
    {
        return unchecked((long)Next());
    }

    /// <summary>Returns an integer over the full unsigned 64-bit range.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    ulong NextU64()
    {
        return Next();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    Int128 NextI128()
    {
        return unchecked((Int128)NextU128());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    UInt128 NextU128()
    {
        return ((UInt128)Next() << 64) | Next();
    }

    /// <summary>
    /// Performs a uniform draw of [low, high)
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    long NextBoundedI64(long low, long high)
    {
        return CitadelRandomExtensions.NextBoundedI64(this, low, high);
    }

    /// <summary>
    /// Performs a uniform draw of [low, high)
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    ulong NextBoundedU64(ulong low, ulong high)
    {
        return CitadelRandomExtensions.NextBoundedU64(this, low, high);
    }

    /// <summary>
    /// Performs a uniform draw of [low, high)
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    float NextBoundedFloat(float low, float high)
    {
        return CitadelRandomExtensions.NextBoundedFloat(this, low, high);
    }

    /// <summary>
    /// Performs a uniform draw of [low, high)
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    double NextBoundedDouble(double low, double high)
    {
        return CitadelRandomExtensions.NextBoundedDouble(this, low, high);
    }
}
