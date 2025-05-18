using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.Database;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarSetupData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarSetup[] m_carSetups;
    public float m_nextFrontWingValue; // Value of front wing after next pit stop - player only

    public override string ToString()
    {
        return $"PacketCarSetupData: {m_nextFrontWingValue}";
    }
};