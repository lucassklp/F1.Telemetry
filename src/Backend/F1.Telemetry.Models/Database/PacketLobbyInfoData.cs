using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.Database;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketLobbyInfoData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    // Packet specific data
    public byte m_numPlayers; // Number of players in the lobby data
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public LobbyInfoData[] m_lobbyPlayers;
};