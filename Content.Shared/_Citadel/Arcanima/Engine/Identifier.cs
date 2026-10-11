namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * An identifier.
 * <br />
 * <br />
 * Used as map tokens and keys in a program.
 * <br />
 * <br />
 * Identifiers exist because it doesn't always make sense to
 * use strings as keys if the frontend for an Arcanima-engine program is
 * something more abstract that doesn't want to allow the user to program
 * text strings for lookups.
 */
public sealed class Identifier(string id)
{
    private readonly string _id = id;
}
