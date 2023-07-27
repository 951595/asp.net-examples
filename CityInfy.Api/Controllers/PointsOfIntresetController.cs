using CityInfy.Api.Mockdata;
using CityInfy.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfy.Api.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsOfIntreset")]
    public class PointsOfIntresetController:ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointsOfIntresetDto>> GetPointsOfIntreset(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(city.pointsOfIntresets);
        }
        [HttpGet("{pointsOfIntresetId}", Name ="GetPointOfIntreset")]
        public ActionResult<PointsOfIntresetDto> GetPointsOfIntresetById(int cityId, int pointsOfIntresetId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var points = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == pointsOfIntresetId);
            if(points == null)
            {
                return NotFound();
            }
            return Ok(points);

        }
        [HttpPost]
        public ActionResult<PointsOfIntresetDto> CreatePointsOfIntreset(int cityId , PointsOfIntresetCreateDto pointsOfIntresetCreate)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxPointsOfIntresetId = CitiesDataStore.Current.Cities.SelectMany(c => c.pointsOfIntresets).Max(p => p.id);
            var finalPoints = new PointsOfIntresetDto()
            {
                id = ++maxPointsOfIntresetId,
                name = pointsOfIntresetCreate.name,
                description = pointsOfIntresetCreate.description
            };
            city.pointsOfIntresets.Add(finalPoints);
            return CreatedAtRoute("GetPointOfIntreset",
                new
                {
                    cityId = cityId,
                    pointsOfIntresetId = finalPoints.id
                },
                finalPoints
                );
        }
        [HttpDelete]
        public ActionResult<PointsOfIntresetDto> DeletePointsOfIntreset(int cityId, int pointsOfIntresetId)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var deletePoints = city.pointsOfIntresets.FirstOrDefault(c => c.id == pointsOfIntresetId);
            if(deletePoints == null)
            {
                return NotFound();
            }
            city.pointsOfIntresets.Remove(deletePoints);
            return NoContent();
        }
    }
}
