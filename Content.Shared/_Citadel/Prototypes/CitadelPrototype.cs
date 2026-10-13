using System.Threading;

namespace Content.Shared._Citadel.Prototypes;

/// <summary>
/// Citadel prototype base. Contains synchronization and database / concurrent access mechanisms,
/// as well as access restrictions.
/// <br />
/// All game prototypes that need to be modifiable / are part of the general world-simulation should implement
/// this eventually.
/// <br />
/// <br />
/// TODO: describe why the hell we need this, synchornization, database, implement
/// </summary>
public sealed class CitadelPrototype : Attribute
{
    internal ReaderWriterLock CoherenceLock { get; } = new();
    internal List<CitadelPrototypeReadLock> ActiveSyncLocks { get; } = new();

    private void marker()
    {
#warning implement write handle / whatnot, and a way to check
    }
}

/// <summary>
/// A read handle that locks a Citadel prototype
/// <br />
/// <br />
/// Should be used when a prototype is being accessed from another thread.
/// <br />
/// </summary>
public sealed class CitadelPrototypeReadLock
{
    private readonly ICitadelPrototype _prototype;

    public CitadelPrototypeReadLock(ICitadelPrototype prototype, string accessorName)
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
    public ref readonly ICitadelPrototype Prototype => ref _prototype;

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

#warning Implement DB serialization and versioning scheme.
