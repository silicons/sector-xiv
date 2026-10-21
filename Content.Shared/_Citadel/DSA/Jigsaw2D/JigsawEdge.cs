namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A tile edge whose data is copied by value when cloned.
/// </summary>
public sealed class JigsawEdge<TEdgeData> : ICloneable
    where TEdgeData : struct
{
    public TEdgeData Data;

    public JigsawEdge<TEdgeData> Clone()
    {
        return new JigsawEdge<TEdgeData> { Data = Data };
    }

    object ICloneable.Clone() => Clone();
}
