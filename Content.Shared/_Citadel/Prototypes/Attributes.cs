using JetBrains.Annotations;

namespace Content.Shared._Citadel.Prototypes;

/// <summary>
/// Citadel prototype base. Defines specific things like database keys for persistence.
/// <br />
/// All game prototypes that need to be modifiable / are part of the general world-simulation should implement
/// this eventually.
/// <br />
/// <br />
/// TODO: describe why the hell we need this, synchornization, database, implement
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[BaseTypeRequired(typeof(ICitadelPrototype))]
[MeansImplicitUse]
[MeansDataDefinition]
public sealed class CitadelPrototypeAttribute : Attribute
{
    public CitadelPrototypeAttribute(int placeholder = 0)
    {
        // don't convert to primary constructor
    }

    private void marker()
    {
#warning implement write handle / whatnot, and a way to check
    }
}

#warning Implement DB serialization and versioning scheme.
