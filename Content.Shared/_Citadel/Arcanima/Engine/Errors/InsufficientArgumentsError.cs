namespace Content.Shared._Citadel.Arcanima.Engine.Errors;

/// <summary>
/// Glyph needed more argument than was available.
/// </summary>
public sealed class InsufficientArgumentsError(int expected, int available) : Error
{
    public readonly int Available = available;
    public readonly int Expected = expected;

    public override string Format()
    {
#warning InsufficientArgumentsError.Format is not implemented.
        throw new NotImplementedException();
    }
}
