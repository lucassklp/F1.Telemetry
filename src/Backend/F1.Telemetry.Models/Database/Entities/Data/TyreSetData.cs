namespace F1.Telemetry.Models.Database.Entities.Data;

public class TyreSetData
{
    public int ActualTyreCompound { get; set; } // Actual tyre compound used
    public int VisualTyreCompound { get; set; } // Visual tyre compound used
    public int Wear { get; set; } // Tyre wear (percentage)
    public int Available { get; set; } // Whether this set is currently available
    public int RecommendedSession { get; set; } // Recommended session for tyre set, see appendix
    public int LifeSpan { get; set; } // Laps left in this tyre set
    public int UsableLife { get; set; } // Max number of laps recommended for this compound
    public int LapDeltaTime { get; set; } // Lap delta time in milliseconds compared to fitted set
    public int Fitted { get; set; } // Whether the set is fitted or not
}
