using System.Collections.Immutable;

namespace Content.Shared._Citadel.Worldgen.Engine;

public sealed class WorldgenConfig(WorldgenConfigBuilder builder)
{
    public ImmutableList<WorldgenLayer> Layers { get; }
}
