using F1.Telemetry.Collector.Boundary;
using F1.Telemetry.Collector.Extensions;
using F1.Telemetry.Models.Database.Entities;
using F1.Telemetry.Web.Persistence;
using PacketHeader = F1.Telemetry.Models.UDP.PacketHeader;

namespace F1.Telemetry.Collector.Processors.Abstractions;

public abstract class Processor<TPacketType, TDatabaseType> : IProcessor 
    where TPacketType : struct
    //where TDatabaseType : class
{
    private string packetName = typeof(TPacketType).Name;
    private Database database;
    protected Processor()
    {
        this.database = new Database(DatabaseConnector.GetDatabase());
    }

    public async Task Process(byte[] data, PacketHeader header)
    {
        Console.WriteLine($"Processing {packetName}");
        TPacketType packet = data.ToStruct<TPacketType>();
        EntityBase<TDatabaseType> entity = Map(packet, header);
        await database.Save(entity);
    }

    protected EntityBase<TDatabaseType> EntityOf(TDatabaseType entity, PacketHeader header)
    {
        return new EntityBase<TDatabaseType>
        {
            CreatedAt = DateTime.UtcNow,
            SessionId = header.m_sessionUID.ToString(),
            Data = entity,
            Timestamp = header.m_sessionTime
        };
    }
    
    public abstract EntityBase<TDatabaseType> Map(TPacketType packet, PacketHeader header);
    
}