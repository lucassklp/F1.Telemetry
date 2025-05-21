namespace F1.Telemetry.Models.Database.Entities.Data;

public class CarSetupData
{
    public byte FrontWing { get; set; } // Front wing aero
    public byte RearWing { get; set; } // Rear wing aero
    public byte OnThrottle { get; set; } // Differential adjustment on throttle (percentage)
    public byte OffThrottle { get; set; } // Differential adjustment off throttle (percentage)
    public float FrontCamber { get; set; } // Front camber angle (suspension geometry)
    public float RearCamber { get; set; } // Rear camber angle (suspension geometry)
    public float FrontToe { get; set; } // Front toe angle (suspension geometry)
    public float RearToe { get; set; } // Rear toe angle (suspension geometry)
    public byte FrontSuspension { get; set; } // Front suspension
    public byte RearSuspension { get; set; } // Rear suspension
    public byte FrontAntiRollBar { get; set; } // Front anti-roll bar
    public byte RearAntiRollBar { get; set; } // Rear anti-roll bar
    public byte FrontSuspensionHeight { get; set; } // Front ride height
    public byte RearSuspensionHeight { get; set; } // Rear ride height
    public byte BrakePressure { get; set; } // Brake pressure (percentage)
    public byte BrakeBias { get; set; } // Brake bias (percentage)
    public byte EngineBraking { get; set; } // Engine braking (percentage)
    public float RearLeftTyrePressure { get; set; } // Rear left tyre pressure (PSI)
    public float RearRightTyrePressure { get; set; } // Rear right tyre pressure (PSI)
    public float FrontLeftTyrePressure { get; set; } // Front left tyre pressure (PSI)
    public float FrontRightTyrePressure { get; set; } // Front right tyre pressure (PSI)
    public byte Ballast { get; set; } // Ballast
    public float FuelLoad { get; set; } // Fuel load
}