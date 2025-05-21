namespace F1.Telemetry.Models.Database.Entities.Data;

public class CarStatusData
{
    public byte TractionControl { get; set; } // Traction control - 0 = off, 1 = medium, 2 = full
    public byte AntiLockBrakes { get; set; } // 0 (off) - 1 (on)
    public byte FuelMix { get; set; } // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
    public byte FrontBrakeBias { get; set; } // Front brake bias (percentage)
    public byte PitLimiterStatus { get; set; } // Pit limiter status - 0 = off, 1 = on
    public float FuelInTank { get; set; } // Current fuel mass
    public float FuelCapacity { get; set; } // Fuel capacity
    public float FuelRemainingLaps { get; set; } // Fuel remaining in terms of laps (value on MFD)
    public ushort MaxRPM { get; set; } // Cars max RPM, point of rev limiter
    public ushort IdleRPM { get; set; } // Cars idle RPM
    public byte MaxGears { get; set; } // Maximum number of gears
    public byte DrsAllowed { get; set; } // 0 = not allowed, 1 = allowed
    public ushort DrsActivationDistance { get; set; } // 0 = DRS not available, non-zero - DRS will be available

    public byte ActualTyreCompound { get; set; } // Tyre compound ID
    public byte VisualTyreCompound { get; set; } // Visual tyre compound ID
    public byte TyresAgeLaps { get; set; } // Age in laps of the current set of tyres
    public sbyte VehicleFiaFlags { get; set; } // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow

    public float EnginePowerICE { get; set; } // Engine power output of ICE (W)
    public float EnginePowerMGUK { get; set; } // Engine power output of MGU-K (W)
    public float ErsStoreEnergy { get; set; } // ERS energy store in Joules
    public byte ErsDeployMode { get; set; } // ERS deployment mode, 0 = none, 1 = medium, 2 = hotlap, 3 = overtake

    public float ErsHarvestedThisLapMGUK { get; set; } // ERS energy harvested this lap by MGU-K
    public float ErsHarvestedThisLapMGUH { get; set; } // ERS energy harvested this lap by MGU-H
    public float ErsDeployedThisLap { get; set; } // ERS energy deployed this lap

    public byte NetworkPaused { get; set; } // Whether the car is paused in a network game
}