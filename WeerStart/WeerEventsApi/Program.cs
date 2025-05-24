using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.WeerStations.Managers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true, true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<WeerStationManager>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();
builder.Services.AddSingleton<IWeerbericht, Weerbericht>();
builder.Services.AddSingleton<IWeerbericht>(sp =>
    new WeerberichtProxy(new Weerbericht())
);

WebApplication app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");
app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());
app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());
app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());
app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());
app.MapPost("/commands/meting-command", (IDomeinController dc) => {
    dc.DoeMetingen();
    return Results.Ok();
});

// Initialize 12 random stations at startup
IServiceProvider provider = app.Services;
IStadManager stadManager = provider.GetRequiredService<IStadManager>();
WeerStationManager stationManager = provider.GetRequiredService<WeerStationManager>();
IEnumerable<WeerEventsApi.Steden.Stad> steden = stadManager.GeefSteden();
stationManager.InitialiseerMetRandomStations(steden, 12);

app.Run();