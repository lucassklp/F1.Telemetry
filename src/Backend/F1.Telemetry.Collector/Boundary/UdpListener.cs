using System.Net.Sockets;
using System.Runtime.InteropServices;
using F1.Telemetry.Collector.Processors;
using F1.Telemetry.Models.UDP;
using Newtonsoft.Json;

namespace F1.Telemetry.Collector.Boundary;

static class UdpListener
{
    private const int ListenPort = 20777;
    private static ProcessorStrategy processorStrategy = new();
    
    public async static Task StartListener()
    {
        using UdpClient listener = new UdpClient(ListenPort);
        Console.WriteLine($"Listening for UDP packets on port {ListenPort}...");
        Database.Initialize();
        
        while (true)
        {
            try
            {
                UdpReceiveResult result = await listener.ReceiveAsync();
                await processorStrategy.Process(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString(), ConsoleColor.Red);
            }
        }
    }
}