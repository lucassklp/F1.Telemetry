using System.Text;
using F1.Telemetry.Collector.Processors.Abstractions;
using F1.Telemetry.Models.Database.Entities;
using F1.Telemetry.Models.Database.Enums;
using F1.Telemetry.Models.UDP;
using PacketParticipantsData = F1.Telemetry.Models.UDP.PacketParticipantsData;
using ParticipantData = F1.Telemetry.Models.Database.Entities.Data.ParticipantData;


namespace F1.Telemetry.Collector.Processors;

public class ParticipantsProcessor : Processor<PacketParticipantsData, ParticipantsEntity>
{
    public override EntityBase<ParticipantsEntity> Map(PacketParticipantsData packet, PacketHeader header)
    {
        
        var participants = new ParticipantsEntity
        {
            NumActiveCars = packet.m_numActiveCars,
            ParticipantsData = packet.m_participants.Select(p => new ParticipantData
            {
                AiControlled = p.m_aiControlled == 1,
                DriverId = p.m_driverId,
                NetworkId = p.m_networkId,
                TeamId = p.m_teamId,
                Name = Encoding.UTF8.GetString(Encoding.Default.GetBytes(p.m_name)).TrimEnd('\0'),
                Telemetry = (YourTelemetry)p.m_yourTelemetry,
                ShowOnlineNames = p.m_showOnlineNames == 1,
                TechLevel = p.m_techLevel,
                Platform = (Platform)p.m_platform,
            })
        };
        
        return EntityOf(participants, header);
    }
}