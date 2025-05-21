using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace F1.Telemetry.Web.Persistence;

public static class DatabaseConnector
{
    private static MongoClient client;
    private static IMongoDatabase database;
    private static string connectionString = "mongodb://f1user:f1pass@localhost:27017/";
    private static string databaseName = "f1_telemetry";

    
    public static void Initialize()
    {
        client = new MongoClient(connectionString);
        database = client.GetDatabase(databaseName);
    }

    public static void Initialize(ILoggerFactory loggerFactory)
    { 
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.LoggingSettings = new LoggingSettings(loggerFactory);
        client = new MongoClient(settings);
        database = client.GetDatabase(databaseName);
    }

    public static IMongoDatabase GetDatabase()
    {
        if (database == null)
        {
            Initialize();
        }
        return database!;
    }
}