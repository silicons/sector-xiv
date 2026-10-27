namespace Content.Shared._Citadel.Worldgen.GridStructures;

/// <summary>
/// Builds a grid structure tile with a weight and directional edges.
/// </summary>
public sealed class GridStructureTileBuilder
{
    private int _weight;
    private GridStructureEdge _north = new();
    private GridStructureEdge _south = new();
    private GridStructureEdge _east = new();
    private GridStructureEdge _west = new();

    public GridStructureTileBuilder WithWeight(int weight)
    {
        _weight = weight;
        return this;
    }

    public GridStructureTileBuilder WithNorth(GridStructureEdge north)
    {
        ArgumentNullException.ThrowIfNull(north);
        _north = north;
        return this;
    }

    public GridStructureTileBuilder WithSouth(GridStructureEdge south)
    {
        ArgumentNullException.ThrowIfNull(south);
        _south = south;
        return this;
    }

    public GridStructureTileBuilder WithEast(GridStructureEdge east)
    {
        ArgumentNullException.ThrowIfNull(east);
        _east = east;
        return this;
    }

    public GridStructureTileBuilder WithWest(GridStructureEdge west)
    {
        ArgumentNullException.ThrowIfNull(west);
        _west = west;
        return this;
    }

    /// <summary>
    /// Creates a tile using the current builder values.
    /// </summary>
    public GridStructureTile Build()
    {
        return new GridStructureTile(_weight, _north, _south, _east, _west);
    }
}
