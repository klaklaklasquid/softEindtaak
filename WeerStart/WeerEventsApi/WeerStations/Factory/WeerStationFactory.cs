using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Stations;

namespace WeerEventsApi.WeerStations.Factory
{
    public static class WeerStationFactory
    {
        public static WeerStation MaakWeerStation(Stad locatie, int type)
        {
            switch (type)
            {
                case 0:
                    return new LuchtdrukStation(locatie);
                case 1:
                    return new NeerslagStation(locatie);
                case 2:
                    return new TemperatuurStation(locatie);
                case 3:
                    return new WindStation(locatie);
                default:
                    throw new ArgumentException("Ongeldig stationtype");
            }
        }

        public static WeerStation MaakRandomWeerStation(Stad locatie)
        {
            var random = new Random();
            int type = random.Next(0, 4);
            return MaakWeerStation(locatie, type);
        }
    }
}