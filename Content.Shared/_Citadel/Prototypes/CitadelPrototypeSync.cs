using System.Threading;

namespace Content.Shared._Citadel.Prototypes;

/// <summary>
/// Synchronization helper. Holds things like a mutation notch
/// and a possible RwLock later.
/// </summary>
public sealed class CitadelPrototypeSync
{
    /// <summary>
    /// A counter that increments (with wrap-around) every time
    /// the prototype is mutated in any way.
    /// <br />
    /// <br />
    /// Things that cache computations should update
    /// their caches if a prototype's mutation notch changes.
    /// </summary>
    private int _mutationNotch;

    /// <summary>
    /// Use when loading mutation notch from another thread.
    /// </summary>
    /// <returns></returns>
    public int SyncLoadMutationNotch()
    {
        return Volatile.Read(ref _mutationNotch);
    }

    /// <summary>
    /// Use when loading mutation notch from the main thread.
    /// </summary>
    public int LoadMutationNotch()
    {
        return _mutationNotch;
    }

    /// <summary>
    /// Interlocked increment of the mutation notch.
    /// Call whenever you finish committing a change to the prototype.
    /// <br />
    /// <br />
    /// This is <b>not</b> synchronization. Non-main-threaded
    /// access to the prototype should still be done with
    /// proper read locks, or the prototype may change
    /// while reading.
    /// <br />
    /// <br />
    /// This is instead meant to be a cheap way to check if a prototype
    /// has changed since the last time something like
    /// cached computations had been done.
    /// </summary>
    public void MarkMutated()
    {
        Interlocked.Add(ref _mutationNotch, 1);
    }
}
