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

#warning Implement DB serialization and versioning scheme.
