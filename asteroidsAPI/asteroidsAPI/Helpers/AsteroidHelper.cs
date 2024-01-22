using asteroidsAPI.Models.DTO;
using Microsoft.OpenApi.Services;

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
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string url = $"{apiUrl}?start_date={initDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&api_key={apiKey}";

                    HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));

                    if (response.IsSuccessStatusCode)
                    {
                       

                        return new List<AsteroidDTO>();
                    }
                   
                    return new List<AsteroidDTO>();
                }
            }
            catch(Exception ex)
            {
                return new List<AsteroidDTO>();
            }
          
        }

       

    }
}
