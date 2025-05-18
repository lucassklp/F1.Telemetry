using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.Database;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketMotionData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarMotion[] m_carMotionData; // Data for all cars on track
};