using System.Runtime.InteropServices;
using F1.Telemetry.Models.Database.Enums;

namespace F1.Telemetry.Models.Database;

public class CarTelemetry
{
    public ushort Speed { get; set; } // Speed of car in kilometres per hour
    public float Throttle { get; set; } // Amount of throttle applied (0.0 to 1.0)
    public float Steer { get; set; } // Steering (-1.0 (full lock left) to 1.0 (full lock right))
    public float Brake { get; set; } // Amount of brake applied (0.0 to 1.0)
    public int Clutch { get; set; } // Amount of clutch applied (0 to 100)
    public Gear Gear { get; set; } // Gear selected (1-8, N=0, R=-1)
    public int EngineRPM { get; set; } // Engine RPM
    public bool Drs { get; set; } // 0 = off, 1 = on
    public int RevLightsPercent { get; set; } // Rev lights indicator (percentage)
    public int[] BrakesTemperature { get; set; } // Brakes temperature (celsius)
    
    public int[] TyresSurfaceTemperature { get; set; } // Tyres surface temperature (celsius)
    public int[] TyresInnerTemperature { get; set; } // Tyres inner temperature (celsius)
    public int EngineTemperature { get; set; } // Engine temperature (celsius)
    public float[] TyresPressure { get; set; } // Tyres pressure (PSI)
    public int[] SurfaceType { get; set; } // Driving surface, see appendices
}