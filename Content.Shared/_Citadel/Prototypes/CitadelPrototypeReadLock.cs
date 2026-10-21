using System.Threading;

namespace Content.Shared._Citadel.Prototypes;

/// <summary>
/// A read handle that locks a Citadel prototype
/// <br />
/// <br />
/// Should be used when a prototype is being accessed from another thread.
/// <br />
/// </summary>
public sealed class CitadelPrototypeReadLock
{
    private readonly CitadelPrototype _prototype;

    public CitadelPrototypeReadLock(CitadelPrototype prototype, string accessorName)
    {
#warning figure out how to do this properly because a thread cannot be locking individually, when it touches prototypes it needs to lock before the task begins.
        _prototype = prototype;
#warning i don't htink i'm rwlocking properly
        _prototype.CoherenceLock.AcquireReaderLock(Timeout.Infinite);
        lock (_prototype.ActiveSyncLocks)
        {
            _prototype.ActiveSyncLocks.Add(this);
        }
    }

    // ReSharper disable once InconsistentlySynchronizedField - we access it before to do a cheap reader lock acq/rel.
    public ref readonly CitadelPrototype Prototype => ref _prototype;

    public void Dispose()
    {
#warning is this going to be called properly?
        _prototype.CoherenceLock.ReleaseReaderLock();
        lock (_prototype.ActiveSyncLocks)
        {
            _prototype.ActiveSyncLocks.Remove(this);
        }
    }
}
