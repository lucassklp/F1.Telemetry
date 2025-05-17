using System.Net.Sockets;
using System.Runtime.InteropServices;
using F1.Telemetry.Models.UDP;
using Newtonsoft.Json;

namespace F1.Telemetry.Collector.Boundary;

static class UdpListener
{
    private const int ListenPort = 20777;
    
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
                ProcessUDP(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString(), ConsoleColor.Red);
            }
        }
    }

    static async Task ProcessUDP(UdpReceiveResult result)
    {
        Console.WriteLine($"Received {result.Buffer.Length} bytes from {result.RemoteEndPoint}");
        
        PacketHeader header = FromByteArray<PacketHeader>(result.Buffer);
        
        Console.WriteLine($"Header PacketId: {header.m_packetId}");

        if (header.m_packetId == 0)
        {
            //Frequency: Rate as specified in menus
            Process<PacketMotionData>(result.Buffer);
        }
        
        else if (header.m_packetId == 100)
        {
            //Frequency: 2 per second
            Process<PacketSessionData>(result.Buffer);
        }
        
        else if (header.m_packetId == 2)
        {
            //Frequency: Rate as specified in menus
            Process<PacketLapData>(result.Buffer);
        }
        
        else if (header.m_packetId == 3)
        {
            //Frequency: When the event occurs
            Process<PacketEventData>(result.Buffer);
        }
        
        else if (header.m_packetId == 4)
        {
            //Frequency: Every 5 seconds
            Process<PacketParticipantsData>(result.Buffer);
        }
        
        else if (header.m_packetId == 5)
        {
            //Frequency: 2 per second
            Process<PacketCarSetupData>(result.Buffer);
        }
        
        else if (header.m_packetId == 6)
        {
            //Frequency: Rate as specified in menus
            Process<PacketCarTelemetryData>(result.Buffer);
        }
        
        else if (header.m_packetId == 7)
        {
            //Frequency: Rate as specified in menus
            Process<PacketCarStatusData>(result.Buffer);
        }
        
        else if (header.m_packetId == 8)
        {
            //Frequency: Once at the end of a race
            Process<PacketFinalClassificationData>(result.Buffer);
        }
        
        else if (header.m_packetId == 9)
        {
            //Frequency: 2 per second when in the lobby
            Process<PacketLobbyInfoData>(result.Buffer);
        }
        
        else if (header.m_packetId == 10)
        {
            //Frequency: 10 per second
            Process<PacketCarDamageData>(result.Buffer);
        }
        
        else if (header.m_packetId == 11)
        {
            //Frequency: 20 per second but cycling through cars
            Process<PacketSessionHistoryData>(result.Buffer);
        }

        else if (header.m_packetId == 12)
        {
            //Frequency: 20 per second but cycling through cars
            Process<PacketTyreSetsData>(result.Buffer);
        }
        
        else if (header.m_packetId == 13)
        {
            //Frequency: Rate as specified in menus
            Process<PacketMotionExData>(result.Buffer);
        }
        
        else if (header.m_packetId == 14)
        {
            //The time trial data gives extra information only relevant to time trial game mode. This packet will not
            //be sent in other game modes.
            //Frequency: 1 per second
            Process<PacketTimeTrialData>(result.Buffer);
        }
    }

    public async static Task Process<T>(byte[] data) where T: struct
    {
        T packet = FromByteArray<T>(data);
        await Database.Save(packet);
    }
    
    public static T FromByteArray<T>(byte[] data) where T : struct
    {
        GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        }
        finally
        {
            handle.Free();
        }
    }
}