using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.UDP;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarDamageData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarDamageData[] m_carDamageData;
};