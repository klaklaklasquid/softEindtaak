using System.Xml.Serialization;

namespace WeerEventsApi.Logging
{
    public class XmlMetingLoggerDecorator : IMetingLogger
    {
        private readonly IMetingLogger _inner;

        public XmlMetingLoggerDecorator(IMetingLogger inner)
        {
            _inner = inner;
        }

        public void Log(string message)
        {
            _inner.Log(message);
            File.AppendAllText("log.xml", message + Environment.NewLine);
        }

        public void LogMeting(object meting)
        {
            var serializer = new XmlSerializer(meting.GetType());
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, meting);
                Log(stringWriter.ToString());
            }
        }
    }
}