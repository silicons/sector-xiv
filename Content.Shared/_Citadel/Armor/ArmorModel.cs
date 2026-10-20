namespace Content.Shared._Citadel.Armor;

public enum ArmorModel
{
    /// <summary>
    /// Flat reductions, with each layer of armor applying coefficients and soaks.
    /// <br />
    /// <br />
    /// Useful for things like radiation, exotic energies, etc, which shouldn't
    /// be easily blocked even by 'high tier' armor.
    /// </summary>
    Flat = 0,

    /// <summary>
    /// Full armor simulation with tier / soak / deflect / coefficient.
    /// <br />
    /// <br />
    /// Generally used for standard physical damage, energetic blasts, etc.
    /// </summary>
    Dynamic = 1,

    /// <summary>
    /// Only simulates armor as a multiplier, ignoring soak, deflect, and tier.
    /// </summary>
    Multiplier = 2,
}
