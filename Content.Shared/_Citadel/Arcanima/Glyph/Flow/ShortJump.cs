using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;

namespace Content.Shared._Citadel.Arcanima.Glyph.Flow;

/**
 * A glyph that jumps to an absolute index in the current glyph chain.
 * <br />
 * <br />
 * <li>Arg 1 (TOP) - Absolute Glyph Index</li>
 */
public sealed class ShortJump(int absoluteIdx) : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (absoluteIdx < 0 || absoluteIdx >= context.Chain.Glyphs.Length)
        {
            return new ExecutionResult
            {
                Error = new OutOfRangeError(absoluteIdx, 0, context.Chain.Glyphs.Length - 1),
            };
        }

        return new ExecutionResult
        {
            JumpTo = new JumpTarget { GlyphIndex = absoluteIdx },
        };
    }

    public override Engine.Glyph Copy()
    {
        return new ShortJump(absoluteIdx);
    }
}
