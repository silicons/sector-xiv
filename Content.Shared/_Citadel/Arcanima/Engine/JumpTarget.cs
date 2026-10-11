namespace Content.Shared._Citadel.Arcanima.Engine;

public struct JumpTarget
{
    /// <summary>
    /// Destination chain, or null to stay in the current chain.
    /// </summary>
    public GlyphChain? Chain;
    public int GlyphIndex;
}
