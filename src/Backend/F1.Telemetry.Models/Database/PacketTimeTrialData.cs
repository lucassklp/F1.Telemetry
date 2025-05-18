using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace F1.Telemetry.Models.Database;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketTimeTrialData
{
    [JsonIgnore]
    public PacketHeader m_header; // Header
    public TimeTrialDataSet m_playerSessionBestDataSet; // Player session best data set
    public TimeTrialDataSet m_personalBestDataSet; // Personal best data set
    public TimeTrialDataSet m_rivalDataSet; // Rival data set
};