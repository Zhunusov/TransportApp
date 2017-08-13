using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TransportApp.DAL.Entities
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public Region()
        {
            Cities = new List<City>();
        }
    }
}
