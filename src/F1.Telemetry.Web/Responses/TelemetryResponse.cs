namespace F1.Telemetry.Web.Responses;

public struct TelemetryResponse
{
    public float Timestamp { get; set; }
    
    public int Speed { get; set; }
    public float Throttle { get; set; }
    public float Steer { get; set; }
    public float Brake { get; set; }
    public byte Clutch { get; set; }
    public int Gear { get; set; }
    public int RPM { get; set; }
    public bool DRS { get; set; }
    
    //public ushort[] BrakesTemperature { get; set; }
//    public byte[] TyresSurfaceTemperature { get; set; }
//    public byte[] TyresInnerTemperature { get; set; }
    //public ushort EngineTemperature { get; set; }
//    public float[] TyresPressure { get; set; }
//    public byte[] SurfaceType { get; set; }
}