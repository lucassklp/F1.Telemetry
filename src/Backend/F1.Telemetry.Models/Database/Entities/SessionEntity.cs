using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;
public class SessionEntity
{
    public int Weather { get; set; } // Weather - 0 = clear, 1 = light cloud, 2 = overcast, etc.
    public int TrackTemperature { get; set; } // Track temp. in degrees celsius
    public int AirTemperature { get; set; } // Air temp. in degrees celsius
    public int TotalLaps { get; set; } // Total number of laps in this race
    public int TrackLength { get; set; } // Track length in metres
    public int SessionType { get; set; } // 0 = unknown, see appendix
    public int TrackId { get; set; } // -1 for unknown, see appendix
    public int Formula { get; set; } // Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2, etc.
    public int SessionTimeLeft { get; set; } // Time left in session in seconds
    public int SessionDuration { get; set; } // Session duration in seconds
    public int PitSpeedLimit { get; set; } // Pit speed limit in km/h
    public int GamePaused { get; set; } // Whether the game is paused – network game only
    public int IsSpectating { get; set; } // Whether the player is spectating
    public int SpectatorCarIndex { get; set; } // Index of the car being spectated
    public int SliProNativeSupport { get; set; } // SLI Pro support, 0 = inactive, 1 = active
    public int NumMarshalZones { get; set; } // Number of marshal zones to follow

    public IEnumerable<MarshalZoneData> MarshalZones { get; set; } // List of marshal zones – max 21

    public int SafetyCarStatus { get; set; } // 0 = no safety car, 1 = full, etc.
    public int NetworkGame { get; set; } // 0 = offline, 1 = online
    public int NumWeatherForecastSamples { get; set; } // Number of weather samples to follow

    public IEnumerable<WeatherForecastSampleData> WeatherForecastSamples { get; set; } // Array of weather forecast samples

    public int ForecastAccuracy { get; set; } // 0 = Perfect, 1 = Approximate
    public int AiDifficulty { get; set; } // AI Difficulty rating – 0-110
    public long SeasonLinkIdentifier { get; set; } // Identifier for season - persists across saves
    public long WeekendLinkIdentifier { get; set; } // Identifier for weekend - persists across saves
    public long SessionLinkIdentifier { get; set; } // Identifier for session - persists across saves
    public int PitStopWindowIdealLap { get; set; } // Ideal lap to pit on for current strategy (player)
    public int PitStopWindowLatestLap { get; set; } // Latest lap to pit on for current strategy (player)
    public int PitStopRejoinPosition { get; set; } // Predicted position to rejoin at (player)
    public int SteeringAssist { get; set; } // 0 = off, 1 = on
    public int BrakingAssist { get; set; } // 0 = off, 1 = low, 2 = medium, 3 = high
    public int GearboxAssist { get; set; } // 1 = manual, 2 = manual & suggested gear, 3 = auto
    public int PitAssist { get; set; } // 0 = off, 1 = on
    public int PitReleaseAssist { get; set; } // 0 = off, 1 = on
    public int ErsAssist { get; set; } // 0 = off, 1 = on
    public int DrsAssist { get; set; } // 0 = off, 1 = on
    public int DynamicRacingLine { get; set; } // 0 = off, 1 = corners only, 2 = full
    public int DynamicRacingLineType { get; set; } // 0 = 2D, 1 = 3D
    public int GameMode { get; set; } // Game mode id - see appendix
    public int RuleSet { get; set; } // Ruleset - see appendix
    public long TimeOfDay { get; set; } // Local time of day - minutes since midnight
    public int SessionLength { get; set; } // 0 = None, 2 = Very Short, 3 = Short, etc.
    public int SpeedUnitsLeadPlayer { get; set; } // 0 = MPH, 1 = KPH
    public int TemperatureUnitsLeadPlayer { get; set; } // 0 = Celsius, 1 = Fahrenheit
    public int SpeedUnitsSecondaryPlayer { get; set; } // 0 = MPH, 1 = KPH
    public int TemperatureUnitsSecondaryPlayer { get; set; } // 0 = Celsius, 1 = Fahrenheit
    public int NumSafetyCarPeriods { get; set; } // Number of safety cars called during session
    public int NumVirtualSafetyCarPeriods { get; set; } // Number of virtual safety cars called
    public int NumRedFlagPeriods { get; set; } // Number of red flags called during session
    public int EqualCarPerformance { get; set; } // 0 = Off, 1 = On
    public int RecoveryMode { get; set; } // 0 = None, 1 = Flashbacks, 2 = Auto-recovery
    public int FlashbackLimit { get; set; } // 0 = Low, 1 = Medium, 2 = High, 3 = Unlimited
    public int SurfaceType { get; set; } // 0 = Simplified, 1 = Realistic
    public int LowFuelMode { get; set; } // 0 = Easy, 1 = Hard
    public int RaceStarts { get; set; } // 0 = Manual, 1 = Assisted
    public int TyreTemperature { get; set; } // 0 = Surface only, 1 = Surface & Carcass
    public int PitLaneTyreSim { get; set; } // 0 = On, 1 = Off
    public int CarDamage { get; set; } // 0 = Off, 1 = Reduced, 2 = Standard, 3 = Simulation
    public int CarDamageRate { get; set; } // 0 = Reduced, 1 = Standard, 2 = Simulation
    public int Collisions { get; set; } // 0 = Off, 1 = Player-to-Player Off, 2 = On
    public int CollisionsOffForFirstLapOnly { get; set; } // 0 = Disabled, 1 = Enabled
    public int MpUnsafePitRelease { get; set; } // 0 = On, 1 = Off (Multiplayer)
    public int MpOffForGriefing { get; set; } // 0 = Disabled, 1 = Enabled (Multiplayer)
    public int CornerCuttingStringency { get; set; } // 0 = Regular, 1 = Strict
    public int ParcFermeRules { get; set; } // 0 = Off, 1 = On
    public int PitStopExperience { get; set; } // 0 = Automatic, 1 = Broadcast, 2 = Immersive
    public int SafetyCar { get; set; } // 0 = Off, 1 = Reduced, 2 = Standard, 3 = Increased
    public int SafetyCarExperience { get; set; } // 0 = Broadcast, 1 = Immersive
    public int FormationLap { get; set; } // 0 = Off, 1 = On
    public int FormationLapExperience { get; set; } // 0 = Broadcast, 1 = Immersive
    public int RedFlags { get; set; } // 0 = Off, 1 = Reduced, 2 = Standard, 3 = Increased
    public int AffectsLicenceLevelSolo { get; set; } // 0 = Off, 1 = On
    public int AffectsLicenceLevelMP { get; set; } // 0 = Off, 1 = On
    public int NumSessionsInWeekend { get; set; } // Number of session in following array

    public byte[] WeekendStructure { get; set; } // List of session types to show weekend structure

    public float Sector2LapDistanceStart { get; set; } // Distance in m around track where sector 2 starts
    public float Sector3LapDistanceStart { get; set; } // Distance in m around track where sector 3 starts
}
