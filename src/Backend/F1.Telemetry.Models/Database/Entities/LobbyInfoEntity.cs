using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

public class LobbyInfoEntity
{
    // Packet specific data
    public int NumPlayers { get; set; } // Number of players in the lobby data
    public IEnumerable<LobbyInfoData> LobbyPlayers { get; set; }
};