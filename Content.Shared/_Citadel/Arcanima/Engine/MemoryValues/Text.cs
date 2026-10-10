namespace Content.Shared._Citadel.Arcanima.Engine.MemoryValues;

public sealed class Text : MemoryValue
{
    public string Value { get; set; } = "";

    public override object Clone()
    {
        return new Text { Value = Value };
    }
}
