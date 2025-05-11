using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.UDP;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketTyreSetsData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    public byte m_carIdx; // Index of the car this data relates to
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public TyreSetData[] m_tyreSetData; // 13 (dry) + 7 (wet)
    public byte m_fittedIdx; // Index into array of fitted tyre
};