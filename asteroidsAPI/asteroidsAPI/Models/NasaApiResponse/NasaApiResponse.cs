using Newtonsoft.Json;

namespace asteroidsAPI.Models.NasaApiResponse
{
    public class NasaApiResponse
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, List<Asteroid>> near_earth_objects { get; set; }
    }
}
