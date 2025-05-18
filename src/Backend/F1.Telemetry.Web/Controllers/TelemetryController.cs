using System.Text;
using F1.Telemetry.Web.Entities;
using F1.Telemetry.Web.Persistence;
using F1.Telemetry.Web.Requests;
using F1.Telemetry.Web.Responses;
using Microsoft.AspNetCore.Mvc;

namespace F1.Telemetry.Web.Controllers;

[Route("api/telemetry")]
public class TelemetryController : Controller
{
    private readonly DaoContext dbContext;
    
    public TelemetryController(DaoContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult Index([FromQuery] MetricsFilter filter)
    {
        var participants = dbContext.Set<PacketParticipantsDataEntity>()
            .OrderByDescending(x => x.Id)
            .First();
        
        var index = new List<int>();

        if (filter.Name == null || filter.Name.Length == 0)
        {
            for (int i = 0; i < participants.Dados.m_participants.Length; i++)
            {
                index.Add(i);
            }
        }
        else
        {
            for (int i = 0; i < participants.Dados.m_participants.Length; i++)
            {
                var participant = participants.Dados.m_participants[i];
                byte[] bytes = Encoding.Default.GetBytes(new String(participant.m_name).Replace("\0", ""));
            
                string nomeCorrigido = Encoding.UTF8.GetString(bytes);
                if (filter.Name.Select(e => e.ToUpper()).Contains(nomeCorrigido))
                {
                    index.Add(i);
                }
            }
        }
        
        var participantNames = index.ToDictionary(
            i => i,
            i => i + " - " +Encoding.UTF8.GetString(Encoding.Default.GetBytes(participants.Dados.m_participants[i].m_name))
                .TrimEnd('\0')
        );
        
        var registros = dbContext.Set<PacketCarTelemetryDataEntity>()
            .Where(t => t.SessionId == participants.SessionId && t.SessionTimestamp > 0)
            .OrderBy(t => t.SessionTimestamp)
            .ToList();
        
        Dictionary<String, List<TelemetryResponse>> response = new Dictionary<String, List<TelemetryResponse>>();
        for (int i = 0; i < index.Count; i++)
        {
            response.Add(participantNames[index[i]], new List<TelemetryResponse>());
        }
        
        for (int r = 0; r < registros.Count; r+=filter.Sensibility)
        {
            var registro = registros[r];
            var telemetries = registro.Dados.m_carTelemetryData;

            for (int i = 0; i < index.Count; i++)
            {
                string participantName = participantNames[index[i]];
                
                var telemetry = telemetries[i];
                response[participantName].Add(new TelemetryResponse
                {
                    Timestamp = registro.SessionTimestamp,
                    Brake = telemetry.m_brake,
                    Clutch = telemetry.m_clutch,
                    DRS = telemetry.m_drs == 1,
                    Gear = telemetry.m_gear,
                    RPM = telemetry.m_engineRPM,
                    Speed = telemetry.m_speed,
                    Steer = telemetry.m_steer,
                    Throttle = telemetry.m_throttle,
                });
            }
        }

        return Ok(response);
    }
}