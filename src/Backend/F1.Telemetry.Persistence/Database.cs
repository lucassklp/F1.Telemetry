using MongoDB.Driver;

namespace F1.Telemetry.Persistence;

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
    
    public static IMongoDatabase GetDatabase() => database;
    
}