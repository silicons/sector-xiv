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
    // private readonly ICitadelPrototype _prototype;

//     public CitadelPrototypeReadLock(ICitadelPrototype prototype, string accessorName)
//     {
// #warning figure out how to do this properly because a thread cannot be locking individually, when it touches prototypes it needs to lock before the task begins.
//         _prototype = prototype;
// #warning i don't htink i'm rwlocking properly
//         _prototype.Sync.CoherenceLock.AcquireReaderLock(Timeout.Infinite);
//         lock (_prototype.Sync.ActiveSyncLocks)
//         {
//             _prototype.Sync.ActiveSyncLocks.Add(this);
//         }
//     }
//
//     // ReSharper disable once InconsistentlySynchronizedField - we access it before to do a cheap reader lock acq/rel.
//     public ref readonly ICitadelPrototype Prototype => ref _prototype;
//
//     public void Dispose()
//     {
// #warning is this going to be called properly?
//         _prototype.Sync.CoherenceLock.ReleaseReaderLock();
//         lock (_prototype.Sync.ActiveSyncLocks)
//         {
//             _prototype.Sync.ActiveSyncLocks.Remove(this);
//         }
//     }
}
