using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportApp.DAL.Entities
{
    public class CargoTransport
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("LoadType")]
        public int LoadTypeId { get; set; }
        public bool IsLoadtypeRequired { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual LoadType LoadType { get; set; }
    }
}
