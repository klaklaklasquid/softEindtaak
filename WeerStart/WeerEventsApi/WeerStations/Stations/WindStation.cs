using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.WeerStations.Stations
{
    public class WindStation : WeerStation
    {
        public WindStation(Stad locatie) : base(locatie) { }

        public override Meting DoeMeting()
        {
            var random = new Random();
            double waarde = random.NextDouble() * 150;
            var meting = new Meting(DateTime.Now, Math.Round(waarde, 2), Eenheid.KilometerPerUur, Locatie);
            VoegMetingToe(meting);
            return meting;
        }
    }
}