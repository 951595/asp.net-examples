using CityInfy.Api.Mockdata;
using CityInfy.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfy.Api.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController:ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCityById(int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == id);
            if(city == null)
            {
                return NotFound("enter correct data city {id}");
            }
            return Ok(city);
        }

    }
}
