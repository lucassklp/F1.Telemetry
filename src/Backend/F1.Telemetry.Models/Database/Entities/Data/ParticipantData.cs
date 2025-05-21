using F1.Telemetry.Models.Database.Enums;

namespace F1.Telemetry.Models.Database.Entities.Data;

public class ParticipantData
{
    public bool AiControlled { get; set; }
    public int DriverId {get; set;}
    public int NetworkId {get; set;}
    public int TeamId {get; set;}
    public String Name {get; set;}
    public YourTelemetry Telemetry {get; set;}
    public bool ShowOnlineNames {get; set;}
    public int TechLevel {get; set;}
    public Platform Platform {get; set;}
}