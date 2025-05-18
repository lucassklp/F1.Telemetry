namespace F1.Telemetry.Models.Database;

public class FinalClassificationData
{
    public byte Position { get; set; } // Finishing position
    public byte NumLaps { get; set; } // Number of laps completed
    public byte GridPosition { get; set; } // Grid position of the car
    public byte Points { get; set; } // Number of points scored
    public byte NumPitStops { get; set; } // Number of pit stops made
    public byte ResultStatus { get; set; } // Result status - 0 = invalid, 1 = inactive, 2 = active
    // 3 = finished, 4 = did not finish, 5 = disqualified
    // 6 = not classified, 7 = retired
    public uint BestLapTimeInMS { get; set; } // Best lap time of the session in milliseconds
    public double TotalRaceTime { get; set; } // Total race time in seconds without penalties
    public byte PenaltiesTime { get; set; } // Total penalties accumulated in seconds
    public byte NumPenalties { get; set; } // Number of penalties applied to this driver
    public byte NumTyreStints { get; set; } // Number of tyre stints up to maximum

    public byte[] TyreStintsActual { get; set; } // Actual tyres used by this driver
    public byte[] TyreStintsVisual { get; set; } // Visual tyres used by this driver
    public byte[] TyreStintsEndLaps { get; set; } // The lap number stints end on
}