namespace Content.Shared._Citadel.Prototypes;

/// <summary>
/// A reference that tracks a Citadel Prototype and its last mutation notch.
/// <br />
/// <br />
/// Used to detect prototype changes.
/// <br />
/// This struct is not thread-safe, and should be owned by one thread at a time.
/// </summary>
public struct CitadelPrototypeRef<T>(T prototype)
    where T : ICitadelPrototype
{
    private int _mutationNotch = prototype.Sync.SyncLoadMutationNotch();

    private T _prototype { get; } = prototype;

    /// <summary>
    /// Checks if the prototype was updated since last update acknowledge.
    /// <br />
    /// Has acq/rel semantics to access.
    /// </summary>
    public bool UpdatePending()
    {
        return _mutationNotch != _prototype.Sync.SyncLoadMutationNotch();
    }

    /// <summary>
    /// <br />
    /// <br />
    /// This is NOT synchronization. You may not use this to
    /// concurrently access a prototype off-main-thread.
    /// <br />
    /// You should use proper read locks for that.
    /// </summary>
    public void Acknowledge()
    {
        _mutationNotch = _prototype.Sync.SyncLoadMutationNotch();
    }

    public T Prototype => _prototype;
}
