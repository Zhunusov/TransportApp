using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.DAL.Entities
{
    public class LoadType
    {        
        public LoadType()
        {
            CargoTransports = new HashSet<CargoTransport>();
            //TransportTypes = new HashSet<TransportType>();
        }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int LoadTypeId { get; set; }
        public string Description { get; set; }       
        public virtual ICollection<CargoTransport> CargoTransports { get; set; }
        //public virtual ICollection<TransportType> TransportTypes { get; set; }
    }
}
