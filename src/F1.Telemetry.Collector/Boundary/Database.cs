using System.Data;
using System.Reflection;
using F1.Telemetry.Models.UDP;
using Npgsql;

namespace F1.Telemetry.Boundary;

public static class Database
{
    private static NpgsqlDataSource dataSource;
    
    public async static Task Initialize()
    {
        Console.WriteLine($"Iniciando banco de dados");
        var connectionString = "Host=localhost;Username=f1user;Password=f1pass;Database=f1_telemetry";
        dataSource = NpgsqlDataSource.Create(connectionString);
        
        var packetClasses = typeof(Models.UDP.CarDamageData).Assembly
            .GetTypes()
            .Where(t => t.Name.StartsWith("Packet"))
            .ToList();

        Console.WriteLine("Criando tabelas...");
        foreach (var cls in packetClasses)
        {
            await CreateTable(cls.Name);
        }
    }

    public async static Task CreateTable(string name)
    {
        Console.WriteLine($"Criando tabela para: {name}");
        var sql = $@"
            DO $$
            BEGIN
                IF NOT EXISTS (
                    SELECT 1 
                    FROM information_schema.tables 
                    WHERE table_name = '{name.ToLower()}'
                ) THEN
                    CREATE TABLE {name} (
                        id SERIAL PRIMARY KEY,
                        data TIMESTAMPTZ DEFAULT NOW(),
                        sessionId text NOT NULL,
                        conteudo text
                    );
                    CREATE INDEX idx_session_id_{name} ON {name} (sessionId);
                END IF;
            END $$;
        ";
        
        await using var command = dataSource.CreateCommand(sql);
        await command.ExecuteNonQueryAsync();
    }

    public async static Task Save(string table, string json, PacketHeader header)
    {
        var sql = $"INSERT INTO {table} (conteudo, sessionId) VALUES (@conteudo, @sessionId)";
        
        await using var cmd = dataSource.CreateCommand(sql);
        
        cmd.Parameters.Add(new NpgsqlParameter("@sessionId", DbType.String)
        {
            Value = header.m_sessionUID.ToString()
        });
        
        cmd.Parameters.Add(new NpgsqlParameter("@conteudo", DbType.String)
        {
            Value = json
        });
        await cmd.ExecuteNonQueryAsync();
    }
}