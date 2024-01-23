using Newtonsoft.Json;

namespace asteroidsAPI.Models.NasaApiResponse
{
    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_hour")]
        public double kilometers_per_hour { get; set; }
    }
}
