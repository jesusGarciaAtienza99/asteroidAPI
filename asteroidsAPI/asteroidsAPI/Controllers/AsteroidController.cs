using asteroidsAPI.Helpers;
using asteroidsAPI.Models;
using asteroidsAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace asteroidsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsteroidController : ControllerBase
    {
       

        
        private readonly NasaApiConfig _apiConfig;
        private AsteroidHelper helper;

        public AsteroidController(IOptions<NasaApiConfig> apiConfig)
        {
            _apiConfig= apiConfig.Value;
            helper = new AsteroidHelper(_apiConfig.ApiKey, _apiConfig.ApiUrl);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsteroids([FromQuery] int days)
        {
            //if(days == null)
            //    return BadRequest("The days parameter is required");
            if (days<1 || days > 7)
            {
                return BadRequest("The days parameter must be a value included in 1 and 7");
            }

            DateTime initDate = DateTime.Now;
            DateTime endDate = initDate.AddDays(days);

            List<AsteroidDTO> asteroids = await helper.getAsteroidsFromNASA(initDate, endDate);

            return Ok(asteroids);

        }

      
    }
}

