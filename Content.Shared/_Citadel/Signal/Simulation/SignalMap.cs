using System.Collections.Concurrent;

namespace Content.Shared._Citadel.Signal.Simulation;

/// <summary>
/// A single 2D plane of signals.
/// </summary>
public sealed class SignalMap
{
    #region Pulses

    /// <summary>
    /// Pulses enqueued to go off.
    /// </summary>
    private ConcurrentQueue<SignalPulse> _enqueuedPulses = new();

    #endregion

    #region Beacons

    //

    #endregion

    #region Fields

    //

    #endregion

    #region Listeners

    //

    #endregion

    #region Spatial Handling

    //

    #endregion

    #region Hierarchy

    private SignalMap? _parent;
    private List<SignalMap>? _children;

    #endregion

    #region Solver

    //

    #endregion
}
