using Content.Shared._Citadel.DSA.Jigsaw2D;

namespace Content.Shared._Citadel.Procedural.Jigsaw;

public sealed class Adjudicator<TPieceData, TTileData> : IJigsawAdjudicator<
    TPieceData, TTileData, EdgeData>
    where TPieceData : struct
    where TTileData : struct
{
    public bool CanEdgeJoin(JigsawEdge<EdgeData> alpha, JigsawEdge<EdgeData> beta)
    {
        return DoEdgesMatch(alpha, beta);
    }

    public bool CanEdgeTouch(JigsawEdge<EdgeData> alpha, JigsawEdge<EdgeData> beta)
    {
        return DoEdgesMatch(alpha, beta);
    }

    private bool DoEdgesMatch(JigsawEdge<EdgeData> alpha, JigsawEdge<EdgeData> beta)
    {
        // relatively dumb algorithm;
        // we only check for require/forbid edges.
        // this 1. means that structures can grow into pretzel shapes
        // and 2. means that you need to use an algorithm
        // that expands from 'pending' edges of placed tiles,
        // because the concept of 'request' but not 'require' is not there.

        // check alpha's match against beta's require
        if (beta.Data.Require.HasValue && (beta.Data.Require.Value & alpha.Data.Match) != beta.Data.Require.Value)
            return false;
        // check beta's match against alpha's require
        if (alpha.Data.Require.HasValue && (alpha.Data.Require.Value & beta.Data.Match) != alpha.Data.Require.Value)
            return false;
        // check alpha's match against beta's forbid
        if (beta.Data.Forbid.HasValue && (beta.Data.Forbid.Value & alpha.Data.Match) != 0)
            return false;
        // check beta's match against alpha's forbid
        if (alpha.Data.Forbid.HasValue && (alpha.Data.Forbid.Value & beta.Data.Match) != 0)
            return false;
        return true;
    }
}
