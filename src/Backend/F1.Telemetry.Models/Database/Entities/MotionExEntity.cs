namespace F1.Telemetry.Models.Database.Entities;
public class MotionExEntity
{
    public float[] SuspensionPosition { get; set; } // Note: All wheel arrays have the following order: RL, RR, FL, FR
    public float[] SuspensionVelocity { get; set; } // RL, RR, FL, FR
    public float[] SuspensionAcceleration { get; set; } // RL, RR, FL, FR
    public float[] WheelSpeed { get; set; } // Speed of each wheel
    public float[] WheelSlipRatio { get; set; } // Slip ratio for each wheel
    public float[] WheelSlipAngle { get; set; } // Slip angles for each wheel
    public float[] WheelLatForce { get; set; } // Lateral forces for each wheel
    public float[] WheelLongForce { get; set; } // Longitudinal forces for each wheel

    public float HeightOfCogAboveGround { get; set; } // Height of centre of gravity above ground
    public float LocalVelocityX { get; set; } // Velocity in local space – metres/s
    public float LocalVelocityY { get; set; } // Velocity in local space
    public float LocalVelocityZ { get; set; } // Velocity in local space
    public float AngularVelocityX { get; set; } // Angular velocity x-component – radians/s
    public float AngularVelocityY { get; set; } // Angular velocity y-component
    public float AngularVelocityZ { get; set; } // Angular velocity z-component
    public float AngularAccelerationX { get; set; } // Angular acceleration x-component – radians/s/s
    public float AngularAccelerationY { get; set; } // Angular acceleration y-component
    public float AngularAccelerationZ { get; set; } // Angular acceleration z-component
    public float FrontWheelsAngle { get; set; } // Current front wheels angle in radians

    public float[] WheelVertForce { get; set; } // Vertical forces for each wheel

    public float FrontAeroHeight { get; set; } // Front plank edge height above road surface
    public float RearAeroHeight { get; set; } // Rear plank edge height above road surface
    public float FrontRollAngle { get; set; } // Roll angle of the front suspension
    public float RearRollAngle { get; set; } // Roll angle of the rear suspension
    public float ChassisYaw { get; set; } // Yaw angle of the chassis relative to the direction of motion - radians
}
