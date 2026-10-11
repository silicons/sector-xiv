using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Engine.Carriers;

/**
 * Interface for carriers that have kinematics.
 */
public interface ICarrierKinematic
{
    /// <summary>
    /// Get relative velocity.
    /// <br />
    /// <br />
    /// Do NOT give the player the real absolute-velocity. This would bypass the game's
    /// balancing and design decisions around location uncertainty.
    /// <br />
    /// Generally, you want to give them the velocity relative to some starting velocity
    /// at the time of the invocation.
    /// </summary>
    /// <returns>Velocity vector.</returns>
    Vec2 GetRelativeVelocity();

    /// <summary>
    /// Get 2d facing angle.
    /// <br />
    /// <br />
    /// Do NOT give the player the real angle. Always give it relative of the carrier's starting
    /// angle.
    /// <br />
    /// Forked carriers should inherit this.
    /// </summary>
    /// <returns>Angle in degrees CW of absolute north.</returns>
    Number GetRelativeAngle();
}
