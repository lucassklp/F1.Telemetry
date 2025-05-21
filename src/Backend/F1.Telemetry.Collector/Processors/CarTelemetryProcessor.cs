using F1.Telemetry.Collector.Processors.Abstractions;
using F1.Telemetry.Models.Database.Entities;
using F1.Telemetry.Models.Database.Entities.Data;
using F1.Telemetry.Models.Database.Enums;
using F1.Telemetry.Models.UDP;

namespace F1.Telemetry.Collector.Processors;

public class CarTelemetryProcessor : Processor<PacketCarTelemetryData, CarTelemetryEntity>
{
    public override EntityBase<CarTelemetryEntity> Map(PacketCarTelemetryData packet, PacketHeader header)
    {
        var carTelemetry = new CarTelemetryEntity
        {
            Telemetries = packet.m_carTelemetryData.Select(t => new TelemetryData
            {
                Speed = t.m_speed,
                Throttle = t.m_throttle,
                Steer = t.m_steer,
                Brake = t.m_brake,
                Clutch = t.m_clutch,
                Gear = (Gear)t.m_gear,
                EngineRPM = t.m_engineRPM,
                Drs = t.m_drs,
                RevLightsPercent = t.m_revLightsPercent,
                BrakesTemperature = t.m_brakesTemperature,
                TyresSurfaceTemperature = t.m_tyresSurfaceTemperature.Select(v => (int)v).ToArray(),
                TyresInnerTemperature = t.m_tyresInnerTemperature.Select(v => (int)v).ToArray(),
                EngineTemperature = t.m_engineTemperature,
                TyresPressure = t.m_tyresPressure,
                SurfaceType = t.m_surfaceType.Select(v => (int)v).ToArray(),
            }),
            PanelIndex = packet.m_mfdPanelIndex,
            PanelIndexSecondaryPlayer = packet.m_mfdPanelIndexSecondaryPlayer,
            SuggestedGear = packet.m_suggestedGear,
        };
        
        return EntityOf(carTelemetry, header);
    }
}