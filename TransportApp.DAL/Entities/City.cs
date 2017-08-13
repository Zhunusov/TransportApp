using System.ComponentModel.DataAnnotations;

namespace TransportApp.DAL.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public int? RegionId { get; set; }
        public int? CountryId { get; set; }
        public virtual Region Region { get; set; }
        public virtual Country Country { get; set; }
    }
}
