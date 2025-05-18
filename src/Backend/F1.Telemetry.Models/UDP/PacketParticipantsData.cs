using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.UDP;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketParticipantsData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    public byte m_numActiveCars; // Number of active cars in the data – should match number of
    // cars on HUD
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public ParticipantData[] m_participants;
};