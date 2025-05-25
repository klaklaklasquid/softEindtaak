using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void LogMeting(Meting meting)
    {
        // No-op for base logger
    }
}