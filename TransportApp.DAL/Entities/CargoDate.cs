using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportApp.DAL.Entities
{
    public class CargoDate
    {
        public DateTime? ShipmentDateStart { get; set; }
        public DateTime? ShipmentDateFinished { get; set; }
        [Key]
        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        public DateTime DateOfFormation { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
