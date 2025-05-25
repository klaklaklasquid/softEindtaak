using System.Xml.Serialization;
using WeerEventsApi.WeerStations.Metingen;
using System.Globalization;

namespace WeerEventsApi.Logging {
    public class XmlMetingLoggerDecorator : IMetingLogger {
        private readonly IMetingLogger _inner;

        public XmlMetingLoggerDecorator(IMetingLogger inner) {
            _inner = inner;
        }

        public void Log(string message) {
            _inner.Log(message);
        }

        public void LogMeting(Meting meting) {
            string moment = meting.Moment.ToString("d/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            string xml =
                $@"<Meting>
	                <Moment>{moment}</Moment>
	                <Waarde>{meting.Waarde.ToString(CultureInfo.InvariantCulture)}</Waarde>
	                <Eenheid>{meting.Eenheid}</Eenheid>
                </Meting>
                ";
            File.AppendAllText("log.xml", xml);
            _inner.LogMeting(meting);
        }
    }
}