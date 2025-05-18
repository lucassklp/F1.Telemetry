namespace F1.Telemetry.Models.Database;

public class CarMotion
{
    public float WorldPositionX { get; set; } // World space X position - metres
    public float WorldPositionY { get; set; } // World space Y position
    public float WorldPositionZ { get; set; } // World space Z position
    public float WorldVelocityX { get; set; } // Velocity in world space X – metres/s
    public float WorldVelocityY { get; set; } // Velocity in world space Y
    public float WorldVelocityZ { get; set; } // Velocity in world space Z
    public short WorldForwardDirX { get; set; } // World space forward X direction (normalised)
    public short WorldForwardDirY { get; set; } // World space forward Y direction (normalised)
    public short WorldForwardDirZ { get; set; } // World space forward Z direction (normalised)
    public short WorldRightDirX { get; set; } // World space right X direction (normalised)
    public short WorldRightDirY { get; set; } // World space right Y direction (normalised)
    public short WorldRightDirZ { get; set; } // World space right Z direction (normalised)
    public float GForceLateral { get; set; } // Lateral G-Force component
    public float GForceLongitudinal { get; set; } // Longitudinal G-Force component
    public float GForceVertical { get; set; } // Vertical G-Force component
    public float Yaw { get; set; } // Yaw angle in radians
    public float Pitch { get; set; } // Pitch angle in radians
    public float Roll { get; set; } // Roll angle in radians
}