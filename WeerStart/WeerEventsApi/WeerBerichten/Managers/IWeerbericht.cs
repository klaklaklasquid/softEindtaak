using WeerEventsApi.Facade.Dto;
using WeerEventsApi.WeerStations.Metingen;

public interface IWeerbericht
{
    WeerBerichtDto GenereerWeerbericht(IEnumerable<Meting> metingen);
}