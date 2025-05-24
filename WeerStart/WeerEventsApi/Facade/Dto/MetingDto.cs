namespace WeerEventsApi.Facade.Dto;

public class MetingDto {
    //TODO
    public DateTime Moment { get; set; }
    public double Waarde { get; set; }
    public string Eenheid { get; set; } = string.Empty;
    public string StadNaam { get; set; } = string.Empty;
}