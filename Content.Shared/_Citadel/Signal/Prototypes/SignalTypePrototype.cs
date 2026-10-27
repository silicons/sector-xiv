using Content.Shared._Citadel.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Shared._Citadel.Signal.Prototypes;

/// <summary>
/// A prototype for a type of signal.
/// <br />
/// <br />
/// The Signal system supports multiple types of signals.
/// <br />
/// You generally shouldn't be using any overly weird types, and
/// honestly I am probably going to regret adding this system
/// later when people start spamming it, but, whatever.
/// </summary>
[Prototype]
[CitadelPrototype]
public sealed class SignalTypePrototype : ICitadelPrototype
{
    public CitadelPrototypeSync Sync { get; } = new();

    /// <inheritdoc />
    [IdDataField]
    public string ID { get; } = default!;

    private void test()
    {
#warning implemenetation marker for this prototype. make 'subspace' and 'electromagnetic'
    }
}
