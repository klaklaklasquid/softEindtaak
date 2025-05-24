using WeerEventsApi.Facade.Dto;
using WeerEventsApi.WeerStations.Metingen;

public class WeerberichtProxy : IWeerbericht
{
    private readonly IWeerbericht _inner;
    private WeerBerichtDto? _cachedReport;
    private DateTime _lastGenerated = DateTime.MinValue;

    public WeerberichtProxy(IWeerbericht inner)
    {
        _inner = inner;
    }

    public WeerBerichtDto GenereerWeerbericht(IEnumerable<Meting> metingen)
    {
        if (_cachedReport == null || (DateTime.Now - _lastGenerated).TotalMinutes > 1)
        {
            _cachedReport = _inner.GenereerWeerbericht(metingen);
            _lastGenerated = DateTime.Now;
        }
        return _cachedReport;
    }
}