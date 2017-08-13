using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.BLL.DTO
{
    public class CityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public int? RegionId { get; set; }
        public int? CountryId { get; set; }
    }
}
