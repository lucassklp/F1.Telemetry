using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace F1.Telemetry.Models.Database.Entities;

public class EntityBase<T>
{
    [NotMapped]
    [BsonId]
    public ObjectId Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public String SessionId { get; set; }
    public float Timestamp { get; set; }
    public T Data { get; set; }
}