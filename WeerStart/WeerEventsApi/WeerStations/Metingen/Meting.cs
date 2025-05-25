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
        public double Waarde { get; set; }
        public Eenheid Eenheid { get; set; }
        public Stad Locatie { get; set; }

        // Parameterless constructor for XML serialization
        public Meting() { }

        public Meting(DateTime moment, double waarde, Eenheid eenheid, Stad locatie) {
            Moment = moment;
            Waarde = waarde;
            Eenheid = eenheid;
            Locatie = locatie;
        }
    }
}
