namespace MovieAPI
{
/*    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }*/

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Genre {  get; set; }
        public string AudienceRating { get; set; }
        public DateOnly Date { get; set; }
        public int ReviewCount { get; set; }

    }
}
