namespace F1.Telemetry.Web.Requests;

public class MetricsFilter
{
    public string[] Name { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int Sensibility { get; set; } = 5;
}