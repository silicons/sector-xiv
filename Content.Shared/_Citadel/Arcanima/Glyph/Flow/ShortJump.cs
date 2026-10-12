using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Flow;

/**
 * A glyph that jumps to an absolute index in the current glyph chain.
 * <br />
 * <br />
 * <li>Arg 1 (TOP) - Absolute Glyph Index (Number, truncated toward zero and cast to int)</li>
 * <br />
 * On success, the operand is consumed.
 */
public sealed class ShortJump : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(0, out var operand))
            return new ExecutionResult { Error = new InsufficientArgumentsError(1, context.Stack.Size) };

        var index = operand.GetMaybeRef<Number>();
        if (index == null)
            return new ExecutionResult
            {
                Error = new BadInputTypeError(operand.GetRef<ValueBase>().GetType(), [typeof(Number)], 0),
            };

        var glyphIndex = (int)Math.Truncate(index.Value);
        if (glyphIndex < 0 || glyphIndex >= context.Chain.Glyphs.Length)
            return new ExecutionResult
            {
                Error = new IntegerOutOfRange(glyphIndex, 0, context.Chain.Glyphs.Length - 1, 0),
            };

        context.Stack.Pop();
        return new ExecutionResult
        {
            JumpTo = new JumpTarget { GlyphIndex = glyphIndex },
        };
    }

    public override Engine.Glyph Copy()
    {
        return new ShortJump();
    }
}
