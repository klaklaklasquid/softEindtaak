using System.Threading;
using WeerEventsApi.Facade.Dto;
using WeerEventsApi.WeerStations.Metingen;

public class Weerbericht : IWeerbericht
{
    public WeerBerichtDto GenereerWeerbericht(IEnumerable<Meting> metingen)
    {
        // Simulate heavy computation
        Thread.Sleep(5000);

        int aantal = metingen.Count();
        string inhoud = $"Op basis van {aantal} metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op {(aantal > 0 && metingen.Average(m => m.Waarde) > 10 ? "goed" : "slecht")} weer.";

        return new WeerBerichtDto
        {
            Moment = DateTime.Now,
            Inhoud = inhoud
        };
    }
}