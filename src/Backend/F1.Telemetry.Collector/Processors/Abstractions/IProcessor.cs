using F1.Telemetry.Models.UDP;

namespace F1.Telemetry.Collector.Processors.Abstractions;

public interface IProcessor
{
    public Task Process(byte[] data, PacketHeader header);
}