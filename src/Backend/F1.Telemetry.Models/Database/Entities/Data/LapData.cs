namespace F1.Telemetry.Models.Database.Entities.Data;

public class LapData
{
    public long LastLapTime { get; set; } // Last lap time in milliseconds
    public long CurrentLapTime { get; set; } // Current time around the lap in milliseconds
    public TimeSpan Sector1 { get; set; }
    public TimeSpan Sector2 { get; set; }
    public TimeSpan DeltaCarInFront { get; set; }
    public TimeSpan DeltaToLeader { get; set; }
    public float LapDistance { get; set; } 
    public float TotalDistance { get; set; }
    public float SafetyCarDelta { get; set; }
    public int CarPosition { get; set; }
    public int CurrentLapNum { get; set; }
    public int PitStatus { get; set; } // 0 = none, 1 = pitting, 2 = in pit area
    public int NumPitStops { get; set; }
    public int Sector { get; set; }
    public int CurrentLapInvalid { get; set; }
    public int Penalties { get; set; }
    public int TotalWarnings { get; set; }
    public int CornerCuttingWarnings { get; set; }
    public int NumUnservedDriveThroughPens { get; set; }
    public int NumUnservedStopGoPens { get; set; }
    public int GridPosition { get; set; }
    public int DriverStatus { get; set; }
    public int ResultStatus { get; set; }
    public int PitLaneTimerActive { get; set; }
    public int PitLaneTimeInLaneInMS { get; set; }
    public int PitStopTimerInMS { get; set; }
    public int PitStopShouldServePen { get; set; }
    public float SpeedTrapFastestSpeed { get; set; }
    public int SpeedTrapFastestLap { get; set; }
}