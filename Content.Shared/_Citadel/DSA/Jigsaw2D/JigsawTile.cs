namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A single tile of a jigsaw puzzle. Stores data on whether it can
/// join to other tiles.
/// </summary>
public struct JigsawTile<TTileData, TEdgeData> where TTileData : struct
    where TEdgeData : struct
{
    public TTileData Data;

    public JigsawEdge<TEdgeData> North;
    public JigsawEdge<TEdgeData> East;
    public JigsawEdge<TEdgeData> South;
    public JigsawEdge<TEdgeData> West;
}
