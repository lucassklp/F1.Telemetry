using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class TimeTrialEntity
{
    public TimeTrialDataSet PlayerSessionBestDataSet { get; set; } // Player session best data set
    public TimeTrialDataSet PersonalBestDataSet { get; set; } // Personal best data set
    public TimeTrialDataSet RivalDataSet { get; set; } // Rival data set
}
