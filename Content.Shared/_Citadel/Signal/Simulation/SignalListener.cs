using System.Collections.Concurrent;

namespace Content.Shared._Citadel.Signal.Simulation;

public sealed class SignalListener
{
    private ConcurrentQueue<SignalPulseReception> _pulseReceptions = new();
}
