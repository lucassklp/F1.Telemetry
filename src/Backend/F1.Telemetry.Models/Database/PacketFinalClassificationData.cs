using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.Database;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketFinalClassificationData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    public byte m_numCars; // Number of cars in the final classification
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public FinalClassificationData[] m_classificationData;
};