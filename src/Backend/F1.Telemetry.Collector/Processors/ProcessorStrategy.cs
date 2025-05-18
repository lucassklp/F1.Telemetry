using System.Net.Sockets;
using F1.Telemetry.Models.UDP;

namespace F1.Telemetry.Collector.Processors;

public class ProcessorStrategy
{
    private Dictionary<int, IProcessor> processors = new()
    {
        {0, new Processor<PacketMotionData>()},
        {1, new Processor<PacketSessionData>()},
        {2, new Processor<PacketLapData>()},
        {3, new Processor<PacketEventData>()},
        {4, new Processor<PacketParticipantsData>()},
        {5, new Processor<PacketCarSetupData>()},
        {6, new Processor<PacketCarTelemetryData>()},
        {7, new Processor<PacketCarStatusData>()},
        {8, new Processor<PacketFinalClassificationData>()},
        {9, new Processor<PacketLobbyInfoData>()},
        {10, new Processor<PacketCarDamageData>()},
        {11, new Processor<PacketSessionHistoryData>()},
        {12, new Processor<PacketTyreSetsData>()},
        {13, new Processor<PacketMotionExData>()},
        {14, new Processor<PacketTimeTrialData>()}
    };
    
    public async Task Process(UdpReceiveResult result)
    {
        Console.WriteLine($"Received {result.Buffer.Length} bytes from {result.RemoteEndPoint}");
        PacketHeader header = result.Buffer.ToStruct<PacketHeader>();
        Console.WriteLine($"Header PacketId: {header.m_packetId}");
        var processor = processors[header.m_packetId];
        await processor.Process(result.Buffer);
    }
}