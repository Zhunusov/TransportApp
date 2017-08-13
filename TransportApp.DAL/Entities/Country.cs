using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TransportApp.DAL.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string ISOCode2 { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }

        public int? UnionId { get; set; }
        public virtual Union Union { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public Country()
        {
            Regions = new List<Region>();
            Cities = new List<City>();
        }

    }
}
