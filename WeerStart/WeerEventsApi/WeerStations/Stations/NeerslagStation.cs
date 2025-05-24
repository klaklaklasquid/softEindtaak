using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.WeerStations.Stations
{
    public class NeerslagStation : WeerStation
    {
        public NeerslagStation(Stad locatie) : base(locatie) { }

        public override Meting DoeMeting()
        {
            var random = new Random();
            double waarde = random.NextDouble() * 50;
            var meting = new Meting(DateTime.Now, Math.Round(waarde, 2), Eenheid.MillimeterPerVierkanteMeterPerUur, Locatie);
            VoegMetingToe(meting);
            return meting;
        }
    }
}