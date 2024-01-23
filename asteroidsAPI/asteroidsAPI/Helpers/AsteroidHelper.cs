using asteroidsAPI.Models.DTO;
using asteroidsAPI.Models.NasaApiResponse;


namespace asteroidsAPI.Helpers
{
    public class AsteroidHelper
    {
        private string apiUrl { get; set; }
        private string apiKey { get; set; }

        public AsteroidHelper(string apiKey, string apiUrl)
        {
            this.apiKey = apiKey;
            this.apiUrl = apiUrl;
        }

        public async Task<List<AsteroidDTO>> getAsteroidsFromNASA(DateTime initDate, DateTime endDate)
        {
            string url = $"{apiUrl}?start_date={initDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&api_key={apiKey}";

            using (HttpClient httpClient = new HttpClient())
            {              

                var response = await httpClient.GetAsync(new Uri(url));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<NasaApiResponse>();
                    return ProcessAsteroidResponse(content);
                }  
                
            }

            throw new Exception($"Unable to get a valid response form {url}");
        }

        private List<AsteroidDTO> ProcessAsteroidResponse(NasaApiResponse response)
        {
            var topAsteroids = new List<AsteroidDTO>();

           
            var biggestAsteroids = response.near_earth_objects
                .SelectMany(x => x.Value)
                .Where(x => x.is_potentially_hazardous_asteroid)
                .OrderByDescending(asteroid => calulateAverageSize(asteroid))
                .Take(3);

            foreach (var asteroid in biggestAsteroids)
            {                
                topAsteroids.Add(new AsteroidDTO
                {
                    name = asteroid.name,
                    diameter = calulateAverageSize(asteroid),
                    velocity = asteroid.close_approach_data[0].relative_velocity.kilometers_per_hour,
                    date = DateTime.Parse(asteroid.close_approach_data[0].close_approach_date),
                    planet = asteroid.close_approach_data[0].orbiting_body
                });
            }

            return topAsteroids;
        }

        private double calulateAverageSize(Asteroid asteroid)
        {
            return (asteroid.estimated_diameter.kilometers.estimated_diameter_max + asteroid.estimated_diameter.kilometers.estimated_diameter_min) / 2;
        }

    }
}
