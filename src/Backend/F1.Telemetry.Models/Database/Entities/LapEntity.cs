using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class LapEntity
{
    public LapData[] LapData { get; set; }
    public int TimeTrialPBCarIdx { get; set; } // Index of Personal Best car in time trial (255 if invalid)
    public int TimeTrialRivalCarIdx { get; set; } // Index of Rival car in time trial (255 if invalid)
};