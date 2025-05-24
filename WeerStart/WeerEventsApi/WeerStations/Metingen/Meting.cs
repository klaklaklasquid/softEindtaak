using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations.Metingen {
    public enum Eenheid {
        KilometerPerUur, // km/h
        MillimeterPerVierkanteMeterPerUur, // mm/m²/h
        GradenCelsius, // °C
        HectoPascal, // hPa
    }

    public class Meting {
        public DateTime Moment { get; set; }
        public Double Waarde { get; set; }
        public Eenheid Eenheid { get; set; }
        public Stad Locatie { get; set; }

        public Meting(DateTime moment, Double waarde, Eenheid eenheid, Stad locatie) {
            Moment = moment;
            Waarde = waarde;
            Eenheid = eenheid;
            Locatie = locatie;
        }
    }
}
