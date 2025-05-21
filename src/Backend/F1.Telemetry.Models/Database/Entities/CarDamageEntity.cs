using System.Runtime.InteropServices;
using F1.Telemetry.Models.Database.Entities.Data;

namespace F1.Telemetry.Models.Database.Entities;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class CarDamageEntity
{
    public IEnumerable<CarDamageData> CarDamages { get; set; }
}