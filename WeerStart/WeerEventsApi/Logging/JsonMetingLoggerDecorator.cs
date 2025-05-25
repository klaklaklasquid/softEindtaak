using System.Globalization;
using System.Text.Json;
using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.Logging {
    public class JsonMetingLoggerDecorator : IMetingLogger {
        private readonly IMetingLogger _inner;

        public JsonMetingLoggerDecorator(IMetingLogger inner) {
            _inner = inner;
        }

        public void Log(string message) {
            _inner.Log(message);
        }

        public void LogMeting(Meting meting) {
            var logObject = new {
                Moment = meting.Moment.ToString("d/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Waarde = meting.Waarde,
                Eenheid = meting.Eenheid.ToString()
            };

            string json = JsonSerializer.Serialize(logObject, new JsonSerializerOptions { WriteIndented = false });
            File.AppendAllText("log.json", json + Environment.NewLine);
            _inner.LogMeting(meting);
        }
    }
}