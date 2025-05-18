using System.Runtime.InteropServices;

namespace F1.Telemetry.Models.Database;

public class CarDamage
{
    public float[] TyresWear { get; set; } // Tyre wear (percentage)
    public byte[] TyresDamage { get; set; } // Tyre damage (percentage)
    public byte[] BrakesDamage { get; set; } // Brakes damage (percentage)
    public int FrontLeftWingDamage { get; set; } // Front left wing damage (percentage)
    public int FrontRightWingDamage { get; set; } // Front right wing damage (percentage)
    public int RearWingDamage { get; set; } // Rear wing damage (percentage)
    public int FloorDamage { get; set; } // Floor damage (percentage)
    public int DiffuserDamage { get; set; } // Diffuser damage (percentage)
    public int SidepodDamage { get; set; } // Sidepod damage (percentage)
    public bool DrsFault { get; set; } // Indicator for DRS fault, 0 = OK, 1 = fault
    public bool ErsFault { get; set; } // Indicator for ERS fault, 0 = OK, 1 = fault
    public int GearBoxDamage { get; set; } // Gear box damage (percentage)
    public int EngineDamage { get; set; } // Engine damage (percentage)
    public int EngineMGUHWear { get; set; } // Engine wear MGU-H (percentage)
    public int EngineESWear { get; set; } // Engine wear ES (percentage)
    public int EngineCEWear { get; set; } // Engine wear CE (percentage)
    public int EngineICEWear { get; set; } // Engine wear ICE (percentage)
    public int EngineMGUKWear { get; set; } // Engine wear MGU-K (percentage)
    public int EngineTCWear { get; set; } // Engine wear TC (percentage)
    public bool EngineBlown { get; set; } // Engine blown, 0 = OK, 1 = fault
    public bool EngineSeized { get; set; } // Engine seized, 0 = OK, 1 = fault
}