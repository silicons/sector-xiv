using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Flow;

/**
 * A glyph that performs a long jump. A long jump is to another Glyph-chain.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Glyph Chain Identifier</li>
 * <li>Arg 2 (TOP) - Glyph Index (truncated toward zero and cast to int)</li>
 * <br />
 * On success, both operands are consumed.
 */
public sealed class LongJump : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(1, out var idValue)
            || !context.Stack.TryPeekFromTop(0, out var indexValue))
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var id = idValue.GetMaybeRef<Ident>();
        var index = indexValue.GetMaybeRef<Number>();
        if (id == null)
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(idValue.GetRef<ValueBase>().GetType(), [typeof(Ident)], 1),
            };
        }

        if (index == null)
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(indexValue.GetRef<ValueBase>().GetType(), [typeof(Number)], 0),
            };
        }

        if (!context.Program.GlyphChains.TryGetValue(id.Value, out var chain))
            return new ExecutionResult { Error = new BadIdentifierError(id.Value) };

        var glyphIndex = (int)Math.Truncate(index.Value);
        if (glyphIndex < 0 || glyphIndex >= chain.Glyphs.Length)
        {
            return new ExecutionResult
            {
                Error = new IntegerOutOfRange(glyphIndex, 0, chain.Glyphs.Length - 1, 0),
            };
        }

        context.Stack.Pop(2);
        return new ExecutionResult
        {
            JumpTo = new JumpTarget { Chain = chain, GlyphIndex = glyphIndex },
        };
    }

    public override Engine.Glyph Copy()
    {
        return new LongJump();
    }
}
