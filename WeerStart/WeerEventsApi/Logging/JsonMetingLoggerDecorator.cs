using System.Text.Json;

namespace WeerEventsApi.Logging
{
    public class JsonMetingLoggerDecorator : IMetingLogger
    {
        private readonly IMetingLogger _inner;

        public JsonMetingLoggerDecorator(IMetingLogger inner)
        {
            _inner = inner;
        }

        public void Log(string message)
        {
            _inner.Log(message);
            File.AppendAllText("log.json", message + Environment.NewLine);
        }

        public void LogMeting(object meting)
        {
            string json = JsonSerializer.Serialize(meting);
            Log(json);
        }
    }
}