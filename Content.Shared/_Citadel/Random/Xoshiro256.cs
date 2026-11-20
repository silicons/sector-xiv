namespace Content.Shared._Citadel.Random;

/// <summary>
/// An implementation of the Xoshiro256** random number generator algorithm.
/// </summary>
/// <param name="seed"></param>
public struct Xoshiro256
{
    public ulong Iterations { get; private set; }

    private ulong _state1;
    private ulong _state2;
    private ulong _state3;
    private ulong _state4;

    public Xoshiro256(ulong seed)
    {
        var splitMix = new SplitMix64(seed);
        _state1 = splitMix.NextInt();
        _state2 = splitMix.NextInt();
        _state3 = splitMix.NextInt();
        _state4 = splitMix.NextInt();
        Iterations = 0;
    }

    /// <summary>
    /// Rotates the bits of a 64-bit unsigned integer to the left by a specified number of positions.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private static ulong _rotl(ulong x, int k)
    {
        return (x << k) | (x >> (64 - k));
    }

    public ulong NextInt()
    {
        Iterations++;

        var result = _rotl(_state1 + _state4, 23) + _state1;

        var t = _state2 << 17;

        _state3 ^= _state1;
        _state4 ^= _state2;
        _state2 ^= _state3;
        _state1 ^= _state4;

        _state3 ^= t;

        _state4 = _rotl(_state4, 45);

        return result;
    }

    public double NextFloat()
    {
        return NextInt() / (double)ulong.MaxValue;
    }
}
