using F1.Telemetry.Models.Database.Enums;

namespace F1.Telemetry.Models.Database.Entities.Data;

public class LobbyInfoData
{
    public bool AiControlled { get; set; } // Whether the vehicle is AI (1) or Human (0) controlled
    public int TeamId { get; set; } // Team id - see appendix (255 if no team currently selected)
    public int Nationality { get; set; } // Nationality of the driver
    public Platform Platform { get; set; } // 1 = Steam, 3 = PlayStation, 4 = Xbox, 6 = Origin, 255 = unknown

    public string Name { get; set; } // Name of participant in UTF-8 format – null terminated

    public int CarNumber { get; set; } // Car number of the player
    public YourTelemetry YourTelemetry { get; set; } // UDP setting: 0 = restricted, 1 = public
    public bool ShowOnlineNames { get; set; } // Online names setting: 0 = off, 1 = on
    public int TechLevel { get; set; } // F1 World tech level
    public int ReadyStatus { get; set; } // 0 = not ready, 1 = ready, 2 = spectating
}