using Newtonsoft.Json;

namespace asteroidsAPI.Models.NasaApiResponse
{
    public class Kilometers
    {
        [JsonProperty("estimated_diameter_min")]
        public double estimated_diameter_min { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double estimated_diameter_max { get; set; }
    }
}
