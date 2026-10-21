namespace Content.Shared._Citadel.Procedural.Jigsaw;

public struct TileData()
{
    /**
     * The weight of this piece as a hint to solvers.
     *
     * The higher it is, the more prioritized it is to be joined first.
     *
     * Pieces that are more picky generally should be more weighty, because
     * otherwise, less picky pieces may get 'first pick' and choke them out.
     */
    public int Weight = 0;
}
