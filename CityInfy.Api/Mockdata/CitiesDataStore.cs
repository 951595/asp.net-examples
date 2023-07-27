using CityInfy.Api.Models;
using System.Collections.Specialized;

namespace CityInfy.Api.Mockdata
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities {get; set;}
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    id = 1,
                    name = "hyd",
                    description = "greater ",
                    pointsOfIntresets = new List<PointsOfIntresetDto>()
                    {
                        new PointsOfIntresetDto()
                        {
                            id= 1,
                            name = "divya",
                            description = "i love you divya"
                        },
                        new PointsOfIntresetDto()
                        {
                            id = 2,
                            name = "ammu",
                            description = "she is so pretty....will we marry"
                        },
                    }
                },
                new CityDto()
                {
                    id = 2,
                    name = "bnglr",
                    description = "wonderfull place",
                    pointsOfIntresets = new List<PointsOfIntresetDto>()
                    {
                        new PointsOfIntresetDto()
                        {
                            id = 3,
                            name = "navi",
                            description = "she is my friend and butiful....."
                        },
                        new PointsOfIntresetDto()
                        {
                            id = 4,
                            name = "ramya",
                            description = "colleague"
                        },
                    }
                }
            };
        }
    }
}
