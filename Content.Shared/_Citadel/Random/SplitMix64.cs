namespace Content.Shared._Citadel.Random;

/// <summary>
/// A simple implementation of the SplitMix64 random number generator algorithm.
/// </summary>
/// <param name="seed"></param>
public sealed class SplitMix64(ulong seed)
{
    private ulong state = seed;

    /// <summary>
    /// Generates a random 64-bit integer using the SplitMix64 algorithm.
    /// </summary>
    /// <returns></returns>
    public ulong nextInt()
    {
        state += 0x9e3779b97f4a7c15; // increment the state variable
        var z = state; // copy the state to a working variable

        // xor the variable with the variable right bit shifted 30
        // then multiply by a constant
        z = (z ^ (z >> 30)) * 0xbf58476d1ce4e5b9;

        // xor the variable with the variable right bit shifted 27
        // then multiply by a constant
        z = (z ^ (z >> 27)) * 0x94d049bb133111eb;

        // return the variable xored with itself right bit shifted 31
        return z ^ (z >> 31);
    }

    /// <summary>
    /// Generates a random floating-point number between 0 and 1 using the SplitMix64 algorithm.
    /// </summary>
    /// <returns></returns>
    public double nextFloat()
    {
        // divide by 2^64 to return a value between 0 and 1
        return nextInt() / (double)ulong.MaxValue;
    }
}
