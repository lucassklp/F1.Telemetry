using System.Reflection;
using F1.Telemetry.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace F1.Telemetry.Web.Persistence;

public class DaoContext : DbContext
{
    private ILoggerFactory loggerFactory;
    private IConfiguration configuration;
    private IHostEnvironment hostEnvironment;

    public DaoContext(
        DbContextOptions<DaoContext> options, 
        ILoggerFactory loggerFactory, 
        IConfiguration configuration, 
        IHostEnvironment hostEnvironment)
        : base(options)
    {
        this.configuration = configuration;
        this.loggerFactory = loggerFactory;
        this.hostEnvironment = hostEnvironment;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("Database"))
            .UseLoggerFactory(loggerFactory);

        if(hostEnvironment.IsDevelopment())
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PacketCarTelemetryDataEntity>();
        modelBuilder.Entity<PacketParticipantsDataEntity>();
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
