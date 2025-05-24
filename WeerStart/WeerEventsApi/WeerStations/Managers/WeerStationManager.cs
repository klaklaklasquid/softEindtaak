using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Factory;
using WeerEventsApi.WeerStations.Metingen;
using WeerEventsApi.WeerStations.Stations;

namespace WeerEventsApi.WeerStations.Managers
{
    public class WeerStationManager
    {
        private readonly List<WeerStation> _stations = new();

        public void VoegStationToe(WeerStation station)
        {
            _stations.Add(station);
        }

        public IReadOnlyList<WeerStation> GeefAlleStations()
        {
            return _stations.AsReadOnly();
        }

        public void DoeMetingenVoorAlleStations()
        {
            foreach (var station in _stations)
            {
                station.DoeMeting();
            }
        }

        public List<Meting> GeefAlleMetingen()
        {
            return _stations.SelectMany(s => s.Metingen).ToList();
        }

        // Optional: Helper to initialize with random stations
        public void InitialiseerMetRandomStations(IEnumerable<Stad> steden, int aantal)
        {
            var stedenLijst = steden.ToList();
            var random = new Random();
            for (int i = 0; i < aantal; i++)
            {
                var stad = stedenLijst[random.Next(stedenLijst.Count)];
                var station = WeerStationFactory.MaakRandomWeerStation(stad);
                VoegStationToe(station);
            }
        }
    }
}