namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * An unique ID for a glyph chain.
 * <br />
 * <br />
 * This is unique within a program, and is used as a key.
 */
public class GlyphChainId : ICloneable
{
    private readonly string _id;

    public GlyphChainId(string id)
    {
        _id = id;
    }

    public object Clone()
    {
        return new GlyphChainId(_id);
    }
}
