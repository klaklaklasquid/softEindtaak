using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.Logging;

public interface IMetingLogger
{
    void Log(string message);
    void LogMeting(Meting meting);
}