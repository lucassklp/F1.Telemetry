namespace F1.Telemetry.Models.Database;

public class EventDataDetails
{
    public FastestLap FastestLap;
    public Retirement Retirement;
    public TeamMateInPits TeamMateInPits;
    public RaceWinner RaceWinner;
    public Penalty Penalty;
    public SpeedTrap SpeedTrap;
    public StartLights StartLights;
    public DriveThroughPenaltyServed DriveThroughPenaltyServed;
    public StopGoPenaltyServed StopGoPenaltyServed;
    public Flashback Flashback;
    public Buttons Buttons;
    public Overtake Overtake;
    public SafetyCar SafetyCar;
    public Collision Collision;
}

public class FastestLap
{
    public byte VehicleIdx { get; set; }
    public float LapTime { get; set; }
}

public class Retirement
{
    public byte VehicleIdx { get; set; }
}

public class TeamMateInPits
{
    public byte VehicleIdx { get; set; }
}

public class RaceWinner
{
    public byte VehicleIdx { get; set; }
}

public class Penalty
{
    public byte PenaltyType { get; set; }
    public byte InfringementType { get; set; }
    public byte VehicleIdx { get; set; }
    public byte OtherVehicleIdx { get; set; }
    public byte Time { get; set; }
    public byte LapNum { get; set; }
    public byte PlacesGained { get; set; }
}

public class SpeedTrap
{
    public byte VehicleIdx { get; set; }
    public float Speed { get; set; }
    public byte IsOverallFastestInSession { get; set; }
    public byte IsDriverFastestInSession { get; set; }
    public byte FastestVehicleIdxInSession { get; set; }
    public float FastestSpeedInSession { get; set; }
}

public class StartLights
{
    public byte NumLights { get; set; }
}

public class DriveThroughPenaltyServed
{
    public byte VehicleIdx { get; set; }
}

public class StopGoPenaltyServed
{
    public byte VehicleIdx { get; set; }
}

public class Flashback
{
    public uint FlashbackFrameIdentifier { get; set; }
    public float FlashbackSessionTime { get; set; }
}

public class Buttons
{
    public uint ButtonStatus { get; set; }
}

public class Overtake
{
    public byte OvertakingVehicleIdx { get; set; }
    public byte BeingOvertakenVehicleIdx { get; set; }
}

public class SafetyCar
{
    public byte SafetyCarType { get; set; }
    public byte EventType { get; set; }
}

public class Collision
{
    public byte Vehicle1Idx { get; set; }
    public byte Vehicle2Idx { get; set; }
}