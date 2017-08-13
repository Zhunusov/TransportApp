using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.BLL.DTO
{
    public class RegionDTO
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int? CountryId { get; set; }
    }
}
