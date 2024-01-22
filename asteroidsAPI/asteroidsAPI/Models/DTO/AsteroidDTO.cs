namespace asteroidsAPI.Models.DTO
{
    public class AsteroidDTO
    {
        public string name { get; set; }
        public double diameter { get; set; }
        public double velocity { get; set; }
        public DateTime date { get; set; }
        public string planet { get; set; }
    }
}
