namespace Content.Shared._Citadel.Arcanima.Engine.Errors;

/// <summary>
/// Glyph encountered an input type that was not expected.
/// </summary>
/// <param name="used"></param>
/// <param name="expected"></param>
/// <param name="index"></param>
public sealed class BadInputTypeError(Type used, Type[] expected, int index) : Error
{
    public readonly Type[] Expected = expected;
    public readonly int Index = index;
    public readonly Type Used = used;
}
