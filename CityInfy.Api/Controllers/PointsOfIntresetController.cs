using CityInfy.Api.Mockdata;
using CityInfy.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfy.Api.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsOfIntreset")]
    public class PointsOfIntresetController:ControllerBase
    {
        private readonly ILogger<PointsOfIntresetController> _Logger;

        public PointsOfIntresetController(ILogger<PointsOfIntresetController> logger)
        {
            _Logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PointsOfIntresetDto>> GetPointsOfIntreset(int cityId)
        {
            try
            {
                throw new Exception("sample exception");
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == cityId);
                if (city == null)
                {
                    _Logger.LogInformation($"city with id {cityId}wasn't found when accessing the pointsofintreset..");
                    return NotFound();
                }
                return Ok(city.pointsOfIntresets);
            }
            catch(Exception ex)
            {
                _Logger.LogCritical($"Exception while getting points of intreset with id {cityId}..", ex);
                return StatusCode(500,"a problem apping while hadling the request...");            }
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
        [HttpDelete("{pointsOfIntresetId}")]
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
        [HttpPut("{pointsOfIntresetId}")]
        public ActionResult<PointsOfIntresetDto> UpdatePointsOfIntreset(int cityId, int pointsOfIntresetId, PointsOfIntresetUpdateDto pointsOfIntresetUpdate)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var updatePoints = city.pointsOfIntresets.FirstOrDefault(c => c.id == pointsOfIntresetId);
            if (updatePoints == null)
            {
                return NotFound();
            }
            updatePoints.name = pointsOfIntresetUpdate.name;
            updatePoints.description = pointsOfIntresetUpdate.description;
            return NoContent();
            
        }
    }
}
