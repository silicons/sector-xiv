namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// Carries execution state.
/// </summary>
public ref struct ExecutionContext
{
    /// <summary>
    /// Index of the glyph being executed in the glyph-chain.
    /// </summary>
    public int GlyphIndex;

    /// <summary>
    /// Stack reference.
    /// </summary>
    public Stack Stack;

    /// <summary>
    /// Memory reference.
    /// </summary>
    public Memory Memory;

    /// <summary>
    /// Carrier reference.
    /// </summary>
    public Carrier Carrier;

    /// <summary>
    /// Invocation reference.
    /// </summary>
    public Invocation Invocation;
}
