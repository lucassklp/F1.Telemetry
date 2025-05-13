using System.ComponentModel.DataAnnotations.Schema;
using F1.Telemetry.Models.UDP;

namespace F1.Telemetry.Web.Entities;

[Table("packetparticipantsdata")]
public class PacketParticipantsDataEntity : DatabaseEntity<PacketParticipantsData>;
