using F1.Telemetry.Web.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var loggerFactory = builder.Services.BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>();

DatabaseConnector.Initialize(loggerFactory);

builder.Services.AddSingleton(DatabaseConnector.GetDatabase());
builder.Services.AddTransient<Database>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();    
}

app.MapControllers();
app.Run();