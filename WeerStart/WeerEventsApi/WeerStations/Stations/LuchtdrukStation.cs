using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.WeerStations.Stations
{
    public class LuchtdrukStation : WeerStation
    {
        public LuchtdrukStation(Stad locatie) : base(locatie) { }

        public override Meting DoeMeting()
        {
            var random = new Random();
            double waarde = random.NextDouble() * (1050 - 950) + 950;
            var meting = new Meting(DateTime.Now, Math.Round(waarde, 2), Eenheid.HectoPascal, Locatie);
            VoegMetingToe(meting);
            return meting;
        }
    }
}
