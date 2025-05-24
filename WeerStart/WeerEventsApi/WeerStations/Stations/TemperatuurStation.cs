using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.WeerStations.Stations
{
    public class TemperatuurStation : WeerStation
    {
        public TemperatuurStation(Stad locatie) : base(locatie) { }

        public override Meting DoeMeting()
        {
            var random = new Random();
            double waarde = random.NextDouble() * (40 + 20) - 20;
            var meting = new Meting(DateTime.Now, Math.Round(waarde, 2), Eenheid.GradenCelsius, Locatie);
            VoegMetingToe(meting);
            return meting;
        }
    }
}