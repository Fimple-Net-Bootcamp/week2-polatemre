namespace SpaceWeatherForecastApi.Application.DTOs.AstronomicalObject
{
    public class SingleAstronomicalObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Distance { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
