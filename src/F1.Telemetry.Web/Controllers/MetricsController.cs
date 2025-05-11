using F1.Telemetry.Web.Entities;
using F1.Telemetry.Web.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace F1.Telemetry.Web.Controllers;

[Route("api/metrics")]
public class MetricsController : Controller
{
    private readonly DaoContext dbContext;
    
    public MetricsController(DaoContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var registros = dbContext.Set<PacketCarTelemetryDataEntity>()
            .Take(100)
            .ToList();
        
        return Ok(registros);
    }
}