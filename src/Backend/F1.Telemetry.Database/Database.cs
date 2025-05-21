using F1.Telemetry.Models.Database.Entities;
using MongoDB.Driver;

namespace F1.Telemetry.Web.Persistence;

public class Database
{
    private IMongoDatabase database;
    
    public Database(IMongoDatabase database)
    {
        this.database = database;
    }

    public IMongoCollection<EntityBase<T>> GetCollection<T>()
    {
        return database.GetCollection<EntityBase<T>>(typeof(T).Name.Replace("Entity", ""));
    }

    public async Task Save<T>(EntityBase<T> entity)
    {
        await GetCollection<T>()
            .InsertOneAsync(entity);
    }
}