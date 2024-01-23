using Newtonsoft.Json;

namespace asteroidsAPI.Models.NasaApiResponse
{
    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public string close_approach_date { get; set; }

        [JsonProperty("relative_velocity")]
        public RelativeVelocity relative_velocity { get; set; }

        [JsonProperty("orbiting_body")]
        public string orbiting_body { get; set; }
    }
}
