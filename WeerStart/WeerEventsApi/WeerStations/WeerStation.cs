using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Metingen;

namespace WeerEventsApi.WeerStations
{
    public abstract class WeerStation
    {
        public Stad Locatie { get; }
        private readonly List<Meting> _metingen = new();

        protected WeerStation(Stad locatie)
        {
            Locatie = locatie;
        }

        public IReadOnlyList<Meting> Metingen => _metingen.AsReadOnly();

        public abstract Meting DoeMeting();

        public event Action<Meting>? MetingGemaakt;

        protected void VoegMetingToe(Meting meting)
        {
            _metingen.Add(meting);
            MetingGemaakt?.Invoke(meting);
        }
    }
}
