using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using F1.Telemetry.Models.UDP;
using Newtonsoft.Json;
using Npgsql;

namespace F1.Telemetry.Boundary;

class UdpListener
{
    private const int ListenPort = 20777;
    
    public async static Task StartListener()
    {
        using (UdpClient listener = new UdpClient(ListenPort))
        {
            Console.WriteLine($"Listening for UDP packets on port {ListenPort}...");
            
            Database.Initialize();
            
            try
            {
                while (true)
                {
                    UdpReceiveResult result = await listener.ReceiveAsync();
                    ProcessUDP(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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
            Process<PacketMotionData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 100)
        {
            Process<PacketSessionData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 2)
        {
            Process<PacketLapData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 3)
        {
            Process<PacketEventData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 4)
        {
            Process<PacketParticipantsData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 5)
        {
            Process<PacketCarSetupData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 6)
        {
            Process<PacketCarTelemetryData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 7)
        {
            Process<PacketCarStatusData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 8)
        {
            Process<PacketFinalClassificationData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 9)
        {
            Process<PacketLobbyInfoData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 10)
        {
            Process<PacketCarDamageData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 11)
        {
            Process<PacketSessionHistoryData>(result.Buffer, header);
        }

        else if (header.m_packetId == 12)
        {
            Process<PacketTyreSetsData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 13)
        {
            Process<PacketMotionExData>(result.Buffer, header);
        }
        
        else if (header.m_packetId == 14)
        {
            Process<PacketMotionExData>(result.Buffer, header);
        }
    }

    public async static Task Process<T>(byte[] data, PacketHeader header) where T: struct
    {
        Type type = typeof(T);
        T packet = FromByteArray<T>(data);
        var json = JsonConvert.SerializeObject(packet);
        await Database.Save(type.Name, json, header);
        //Console.WriteLine($"{type.Name}: ({packet}) {json}");
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