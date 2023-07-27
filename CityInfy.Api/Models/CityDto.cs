namespace CityInfy.Api.Models
{
    public class CityDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? description { get; set; }

        public int NumberOfPointsIntreset
        {
            get
            {
                return pointsOfIntresets.Count;
            }
        }
        public ICollection<PointsOfIntresetDto> pointsOfIntresets { get; set; } = new List<PointsOfIntresetDto>();
    }

}
