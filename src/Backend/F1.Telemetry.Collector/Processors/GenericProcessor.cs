using F1.Telemetry.Collector.Processors.Abstractions;
using F1.Telemetry.Models.Database;
using F1.Telemetry.Models.Database.Entities;
using PacketHeader = F1.Telemetry.Models.UDP.PacketHeader;

namespace F1.Telemetry.Collector.Processors;

public class GenericProcessor<TPacketType> : Processor<TPacketType, TPacketType> 
    where TPacketType : struct
{
    public override EntityBase<TPacketType> Map(TPacketType packet, PacketHeader header)
    {
        return EntityOf(packet, header);
    }
}