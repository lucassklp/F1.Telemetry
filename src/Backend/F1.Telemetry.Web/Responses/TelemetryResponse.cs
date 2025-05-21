namespace F1.Telemetry.Web.Responses;

public struct TelemetryResponse
{
    public float Timestamp { get; set; }
    
    public int Speed { get; set; }
    public float Throttle { get; set; }
    public float Steer { get; set; }
    public float Brake { get; set; }
    public int Clutch { get; set; }
    public int Gear { get; set; }
    public int RPM { get; set; }
    public int DRS { get; set; }
}