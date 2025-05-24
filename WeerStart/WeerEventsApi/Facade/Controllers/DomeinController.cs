using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.WeerStations.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController {
    private readonly IStadManager _stadManager;
    private readonly WeerStationManager _weerStationManager;
    private readonly IWeerbericht _weerbericht;

    public DomeinController(IStadManager stadManager, WeerStationManager weerStationManager, IWeerbericht weerbericht) {
        _stadManager = stadManager;
        _weerStationManager = weerStationManager;
        _weerbericht = weerbericht;

    }

    public IEnumerable<StadDto> GeefSteden() {
        return _stadManager.GeefSteden().Select(s => new StadDto {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations() {
        //TODO
        return _weerStationManager.GeefAlleStations().Select(ws => new WeerStationDto {
            Type = ws.GetType().Name,
            StadNaam = ws.Locatie.Naam
        });
    }

    public IEnumerable<MetingDto> GeefMetingen() {
        //TODO
        return _weerStationManager.GeefAlleMetingen().Select(m => new MetingDto {
            Moment = m.Moment,
            Waarde = m.Waarde,
            Eenheid = m.Eenheid.ToString(),
            StadNaam = m.Locatie.Naam
        });
    }

    public void DoeMetingen() {
        //TODO
        _weerStationManager.DoeMetingenVoorAlleStations();
    }

    public WeerBerichtDto GeefWeerbericht() {
        var metingen = _weerStationManager.GeefAlleMetingen();
        return _weerbericht.GenereerWeerbericht(metingen);
    }
}