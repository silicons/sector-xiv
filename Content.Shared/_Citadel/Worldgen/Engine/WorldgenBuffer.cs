using Robust.Shared.Physics;

namespace Content.Shared._Citadel.Worldgen.Engine;

/// <summary>
/// A buffer for world generation.
/// <br />
/// <br />
/// Holds all in-progress state so a separate thread may act without
/// needing to work on the main thread.
/// </summary>
public sealed class WorldgenBuffer
{
    /// <summary>
    /// Placed 'fixtures'.
    /// <br />
    /// <br />
    /// Fixtures are larger objects that should block other fixtures from being placed in the same place.
    /// </summary>
    private PhysicalPlacements _fixtures = new();

    /// <summary>
    /// Placed 'spots'
    /// <br />
    /// <br />
    /// Spots are smaller objects.
    /// </summary>
    private PhysicalPlacements _spots = new();

    private struct Positioned<T>(T token, Vector2d pos) where T : WorldgenToken
    {
        public T Token = token;
        public Vector2d Position = pos;
    }

    private struct PhysicalPlacements<T>() where T : WorldgenToken
    {
        public B2DynamicTree<T> Tree = new();
        public List<Positioned<T>> List = new();
    }
}
