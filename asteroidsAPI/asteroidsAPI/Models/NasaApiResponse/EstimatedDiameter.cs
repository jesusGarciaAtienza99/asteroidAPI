using Newtonsoft.Json;

namespace asteroidsAPI.Models.NasaApiResponse
{
    public class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public Kilometers kilometers { get; set; }

    }
}
