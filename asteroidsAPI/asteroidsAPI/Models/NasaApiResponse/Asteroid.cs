using Newtonsoft.Json;

namespace asteroidsAPI.Models.NasaApiResponse
{
    public class Asteroid
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter estimated_diameter { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> close_approach_data { get; set; }
        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool is_potentially_hazardous_asteroid { get; set; }
    }
}
