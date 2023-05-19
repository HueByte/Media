using Expert.Api;
using Expert.Api.Configuration;
using Expert.Api.Middlewares;
using Expert.Infrastructure;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// config
var configRef = builder.Configuration;
configRef.SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// services
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen();

builder.Services.AddServices()
    .AddDatabase(configRef)
    .AddOptions()
    .AddSecurity(configRef);

// logging
Serilog.Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateBootstrapLogger();

var logger = new SerilogLoggerProvider(Serilog.Log.Logger)
    .CreateLogger(nameof(Program));

builder.Host.UseSerilog((context, services, configuration) =>
    configuration
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Error)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.Async(sink => sink.Console(theme: AnsiConsoleTheme.Code))
    .WriteTo.Async(sink => sink.File(Path.Combine(AppContext.BaseDirectory, "logs/media.log"), rollingInterval: RollingInterval.Hour))
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services));

// app
var app = builder.Build();

// database 
await app.SeedDataAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMediaErrorHandler();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSerilogRequestLogging();
app.MapControllers();

app.MapFallbackToFile("index.html");

var dbIstanceHolder = new MemoDb();
dbIstanceHolder.Context = app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<MediaContext>();

app.Run();

class MemoDb
{
    public MediaContext? Context { get; set; }
}
