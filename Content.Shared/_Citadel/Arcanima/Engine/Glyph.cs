namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * An instruction for a program to execute.
 * <br />
 * <br />
 * Because Project Arcanima is a system for a game and isn't an actual generalized architecture,
 * this is not called an 'instruction', because these can do very complicated operations
 * <i>and</i>
 * will
 * actually store metadata.
 */
public abstract class Glyph
{
    public abstract void Execute(CarrierThread thread);
}
