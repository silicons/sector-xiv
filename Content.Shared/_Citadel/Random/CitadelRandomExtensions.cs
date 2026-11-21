using System.Numerics;
using System.Runtime.CompilerServices;

namespace Content.Shared._Citadel.Random;

public static class CitadelRandomExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static long NextBoundedI64(ICitadelRandom random, long low, long high)
    {
        if (low > high)
            throw new ArgumentOutOfRangeException(nameof(high), "The upper bound must be at least the lower bound.");
        if (low == high)

            return low;

        // Unsigned arithmetic also handles intervals spanning more than long.MaxValue values.
        var width = unchecked((ulong)high - (ulong)low);

        return unchecked((long)((ulong)low + NextBoundedUInt64(random, width)));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ulong NextBoundedU64(ICitadelRandom random, ulong low, ulong high)
    {
        if (low > high)
            throw new ArgumentOutOfRangeException(nameof(high), "The upper bound must be at least the lower bound.");
        if (low == high)
            return low;

        return low + NextBoundedUInt64(random, high - low);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong NextBoundedUInt64(ICitadelRandom random, ulong bound)
    {
        // floor(((high << 64) | low) * bound / 2^128), using two 64x64 products.
        // Exactly two draws, with no rejection or division. For uniform 128-bit input, bucket counts
        // differ by at most one; total variation from uniform is less than 2^-66 for any 64-bit bound.
        var result = Math.BigMul(random.Next(), bound, out var middle);
        var lowContribution = Math.BigMul(random.Next(), bound, out _);
        var carry = (ulong)(((UInt128)middle + lowContribution) >> 64);
        return result + carry;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float NextBoundedFloat(ICitadelRandom random, float low, float high)
    {
        ValidateFloatingBounds(low, high);

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        return low == high ? low : ScaleFloating(low, high, random.NextFloat());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static double NextBoundedDouble(ICitadelRandom random, double low, double high)
    {
        ValidateFloatingBounds(low, high);

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        return low == high ? low : ScaleFloating(low, high, random.NextDouble());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ValidateFloatingBounds<T>(T low, T high) where T : IFloatingPointIeee754<T>
    {
        if (!T.IsFinite(low))
            throw new ArgumentOutOfRangeException(nameof(low), "Bounds must be finite.");
        if (!T.IsFinite(high) || low > high)
        {
            throw new ArgumentOutOfRangeException(nameof(high),
                "The upper bound must be finite and at least the lower bound.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T ScaleFloating<T>(T low, T high, T sample) where T : IFloatingPointIeee754<T>
    {
        var width = high - low;
        var value = T.IsFinite(width)
            ? low + width * sample
            // If the width is infinite, high - low overflowed,
            // so use a different strategy; scale the endpoints
            // and then sample.
            : low * (T.One - sample) + high * sample;

        // Scaling can round to high, preserve exclusive upper bound semantics
        return value >= high ? T.BitDecrement(high) : value;
    }
}
