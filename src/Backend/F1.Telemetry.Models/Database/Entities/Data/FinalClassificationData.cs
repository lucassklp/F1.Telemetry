namespace F1.Telemetry.Models.Database.Entities.Data;

public class FinalClassificationData
{
    public int Position { get; set; } // Finishing position
    public int NumLaps { get; set; } // Number of laps completed
    public int GridPosition { get; set; } // Grid position of the car
    public int Points { get; set; } // Number of points scored
    public int NumPitStops { get; set; } // Number of pit stops made
    public int ResultStatus { get; set; } // Result status - 0 = invalid, 1 = inactive, 2 = active
    // 3 = finished, 4 = did not finish, 5 = disqualified
    // 6 = not classified, 7 = retired
    public long BestLapTimeInMS { get; set; } // Best lap time of the session in milliseconds
    public double TotalRaceTime { get; set; } // Total race time in seconds without penalties
    public int PenaltiesTime { get; set; } // Total penalties accumulated in seconds
    public int NumPenalties { get; set; } // Number of penalties applied to this driver
    public int NumTyreStints { get; set; } // Number of tyre stints up to maximum

    public int[] TyreStintsActual { get; set; } // Actual tyres used by this driver
    public int[] TyreStintsVisual { get; set; } // Visual tyres used by this driver
    public int[] TyreStintsEndLaps { get; set; } // The lap number stints end on
}