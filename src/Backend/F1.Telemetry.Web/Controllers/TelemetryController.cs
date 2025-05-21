using F1.Telemetry.Models.Database.Entities;
using F1.Telemetry.Models.Database.Entities.Data;
using F1.Telemetry.Web.Persistence;
using F1.Telemetry.Web.Requests;
using F1.Telemetry.Web.Responses;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace F1.Telemetry.Web.Controllers;

[Route("api/telemetry")]
public class TelemetryController : Controller
{
    private readonly Database database;
    
    public TelemetryController(Database database)
    {
        this.database = database;
    }
    
    [HttpGet]
    public IActionResult Index([FromQuery] MetricsFilter filter)
    {
        var participantsEntity = database.GetCollection<ParticipantsEntity>()
            .AsQueryable()
            .OrderByDescending(x => x.CreatedAt)
            .First();
            
        var participants = participantsEntity
            .Data
            .ParticipantsData
            .ToList();
        
        var participantsData = new Dictionary<int, ParticipantData>();
        
        for (int i = 0; i < participants.Count; i++)
        {
            var participant = participants[i];
            if (filter.Name.Any(name => participant.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                participantsData.Add(i, participant);
            }
        }

        var collection = database.GetCollection<CarTelemetryEntity>();
        var carTelemetries = collection
            .Find(e => e.SessionId == participantsEntity.SessionId && e.Timestamp > 0)
            .SortBy(e => e.Timestamp)
            .Project(e => e.Data.Telemetries.Select(t => new TelemetryResponse
            {
                Timestamp = e.Timestamp,
                Speed = t.Speed,
                Throttle = t.Throttle,
                Steer = t.Steer,
                Brake = t.Brake,
                Clutch = t.Clutch,
                Gear = (int)t.Gear,
                RPM = t.EngineRPM,
                DRS = t.Drs
            }))
            .ToList();
        
        Dictionary<string, List<TelemetryResponse>> response = new();

        foreach (var participant in participantsData)
        {
            response.Add(participant.Value.Name, new List<TelemetryResponse>());
        }
        
        for (int r = 0; r < carTelemetries.Count; r+=filter.Sensibility)
        {
            var carTelemetry = carTelemetries[r];

            foreach (var participant in participantsData)
            {
                response[participant.Value.Name].Add(carTelemetry.ElementAt(participant.Key));
            }
        }
        
        return Ok(response);
    }
}