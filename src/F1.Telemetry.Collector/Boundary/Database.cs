using System.Data;
using System.Reflection;
using F1.Telemetry.Models.UDP;
using MongoDB.Driver;
using Npgsql;

namespace F1.Telemetry.Collector.Boundary;

public static class Database
{
    private static MongoClient client;
    private static IMongoDatabase database;
    
    public static void Initialize()
    {
        Console.WriteLine("Connecting to database...");
        client = new MongoClient("mongodb://f1user:f1pass@localhost:27017/");
        database = client.GetDatabase("f1_telemetry");
        Console.WriteLine("Database connected.");
    }
    
    public async static Task Save<T>(T packet)
    {
        await database.GetCollection<T>(typeof(T).Name)
            .InsertOneAsync(packet);
    }
}