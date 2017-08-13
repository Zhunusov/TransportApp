using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TransportApp.DAL.Entities
{
    public class Union
    {
        [Key]
        public int UnionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
        public Union()
        {
            Countries = new List<Country>();
        }

    }
}
