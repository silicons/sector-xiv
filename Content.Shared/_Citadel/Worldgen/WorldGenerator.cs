using System.Threading;
using System.Threading.Tasks;
using Content.Shared._Citadel.Worldgen.Engine;

namespace Content.Shared._Citadel.Worldgen;

/// <summary>
/// World Generator Module
/// <br />
/// <br />
/// 'World' is defined as a single Map (or a collection of vertically aligned Maps when we are Multi-Z).
/// </summary>
public sealed class WorldGenerator
{
    public Task<WorldgenOutput> Generate(WorldgenRequest request, CancellationToken cancellationToken)
    {
#warning impl
    }
}
