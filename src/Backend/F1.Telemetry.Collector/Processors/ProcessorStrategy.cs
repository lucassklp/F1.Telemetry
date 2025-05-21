using System.Net.Sockets;
using F1.Telemetry.Collector.Extensions;
using F1.Telemetry.Collector.Processors.Abstractions;
using F1.Telemetry.Models.UDP;

namespace F1.Telemetry.Collector.Processors;

public class ProcessorStrategy
{
    private Dictionary<int, IProcessor> processors = new()
    {
        //{0, new GenericProcessor<PacketMotionData>()},
        //{1, new GenericProcessor<PacketSessionData>()},
        //{2, new GenericProcessor<PacketLapData>()},
        //{3, new GenericProcessor<PacketEventData>()},
        {4, new ParticipantsProcessor()},
        //{5, new GenericProcessor<PacketCarSetupData>()},
        {6, new CarTelemetryProcessor()},
        // {7, new GenericProcessor<PacketCarStatusData>()},
        // {8, new GenericProcessor<PacketFinalClassificationData>()},
        // {9, new GenericProcessor<PacketLobbyInfoData>()},
        // {10, new GenericProcessor<PacketCarDamageData>()},
        // {11, new GenericProcessor<PacketSessionHistoryData>()},
        // {12, new GenericProcessor<PacketTyreSetsData>()},
        // {13, new GenericProcessor<PacketMotionExData>()},
        // {14, new GenericProcessor<PacketTimeTrialData>()}
    };
    
    public async Task Process(UdpReceiveResult result)
    {
        Console.WriteLine($"Received {result.Buffer.Length} bytes from {result.RemoteEndPoint}");
        PacketHeader header = result.Buffer.ToStruct<PacketHeader>();
        Console.WriteLine($"Header PacketId: {header.m_packetId}");
        if (processors.TryGetValue(header.m_packetId, out var processor))
        {
            await processor.Process(result.Buffer, header);   
        }
    }
}