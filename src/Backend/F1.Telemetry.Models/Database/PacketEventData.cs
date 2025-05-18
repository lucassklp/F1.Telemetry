using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.Database;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketEventData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_eventStringCode; // Event string code, see below
    
    public EventDataDetails m_eventDetails; // Event details - should be interpreted differently
    // for each type
};