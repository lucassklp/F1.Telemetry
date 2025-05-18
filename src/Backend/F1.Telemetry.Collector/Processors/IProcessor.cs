namespace F1.Telemetry.Collector.Processors;

public interface IProcessor
{
    public Task Process(byte[] data);
}