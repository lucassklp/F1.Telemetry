using System.Runtime.InteropServices;

namespace F1.Telemetry.Models.UDP;

[StructLayout(LayoutKind.Explicit)]
public struct EventDataDetails
{
    [FieldOffset(0)]
    public FastestLap FastestLap;

    [FieldOffset(0)]
    public Retirement Retirement;

    [FieldOffset(0)]
    public TeamMateInPits TeamMateInPits;

    [FieldOffset(0)]
    public RaceWinner RaceWinner;

    [FieldOffset(0)]
    public Penalty Penalty;

    [FieldOffset(0)]
    public SpeedTrap SpeedTrap;

    [FieldOffset(0)]
    public StartLights StartLights;

    [FieldOffset(0)]
    public DriveThroughPenaltyServed DriveThroughPenaltyServed;

    [FieldOffset(0)]
    public StopGoPenaltyServed StopGoPenaltyServed;

    [FieldOffset(0)]
    public Flashback Flashback;

    [FieldOffset(0)]
    public Buttons Buttons;

    [FieldOffset(0)]
    public Overtake Overtake;

    [FieldOffset(0)]
    public SafetyCar SafetyCar;

    [FieldOffset(0)]
    public Collision Collision;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FastestLap
{
    public byte vehicleIdx;
    public float lapTime;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Retirement
{
    public byte vehicleIdx;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TeamMateInPits
{
    public byte vehicleIdx;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct RaceWinner
{
    public byte vehicleIdx;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Penalty
{
    public byte penaltyType;
    public byte infringementType;
    public byte vehicleIdx;
    public byte otherVehicleIdx;
    public byte time;
    public byte lapNum;
    public byte placesGained;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SpeedTrap
{
    public byte vehicleIdx;
    public float speed;
    public byte isOverallFastestInSession;
    public byte isDriverFastestInSession;
    public byte fastestVehicleIdxInSession;
    public float fastestSpeedInSession;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StartLights
{
    public byte numLights;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct DriveThroughPenaltyServed
{
    public byte vehicleIdx;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StopGoPenaltyServed
{
    public byte vehicleIdx;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Flashback
{
    public uint flashbackFrameIdentifier;
    public float flashbackSessionTime;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Buttons
{
    public uint buttonStatus;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Overtake
{
    public byte overtakingVehicleIdx;
    public byte beingOvertakenVehicleIdx;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SafetyCar
{
    public byte safetyCarType;
    public byte eventType;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Collision
{
    public byte vehicle1Idx;
    public byte vehicle2Idx;
}
