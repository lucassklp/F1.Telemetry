using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class EventEntity
{
    public byte[] EventStringCode { get; set; }
    public EventDetailsData EventDetails { get; set; }
}