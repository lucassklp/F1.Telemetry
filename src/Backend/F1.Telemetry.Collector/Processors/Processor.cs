using F1.Telemetry.Collector.Boundary;

namespace F1.Telemetry.Collector.Processors;

public class Processor<T> : IProcessor where T : struct
{
    private String processorName = typeof(T).Name;

    public async Task Process(byte[] data)
    {
        Console.WriteLine($"Processing {processorName}");
        T packet = data.ToStruct<T>();
        await Database.Save(packet);
    }
    
}