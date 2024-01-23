using asteroidsAPI.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace AsteroidsTest
{
    public class AsteroidHelperTests
    {

        private string ApiKey = "zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";
        private string ApiUrl = "https://api.nasa.gov/neo/rest/v1/feed";
    
        [Fact]
        public async Task GetAsteroidsFromNASA_Success()
        {

            AsteroidHelper asteroidHelper = new AsteroidHelper(ApiKey,ApiUrl);

            DateTime init = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(1);
            var result = await asteroidHelper.getAsteroidsFromNASA(init, end);
            
            Assert.NotNull(result);                
          
        }

        [Fact]
        public async Task GetAsteroidsFromNASA_Failure()
        {
            AsteroidHelper asteroidHelper = new AsteroidHelper(ApiKey, ApiUrl+"URLINCORRECT");

            DateTime init = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(1);
           
            await Assert.ThrowsAsync<Exception>(async () => await asteroidHelper.getAsteroidsFromNASA(init, end));

            
        }
    }
}