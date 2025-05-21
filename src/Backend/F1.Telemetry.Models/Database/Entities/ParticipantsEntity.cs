using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class ParticipantsEntity
{
    public int NumActiveCars { get; set; }
    public IEnumerable<ParticipantData> ParticipantsData { get; set; }
};