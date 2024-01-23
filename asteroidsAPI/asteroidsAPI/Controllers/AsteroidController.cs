using asteroidsAPI.Helpers;
using asteroidsAPI.Models;
using asteroidsAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> GetAsteroids([FromQuery, Required, Range(1, 7)] int days)
        {
            
            DateTime initDate = DateTime.Now;
            DateTime endDate = initDate.AddDays(days);

            try
            {
                List<AsteroidDTO> asteroids = await helper.getAsteroidsFromNASA(initDate, endDate);
                return Ok(asteroids);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }

      
    }
}

