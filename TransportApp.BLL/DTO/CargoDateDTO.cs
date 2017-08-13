using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TransportApp.BLL.DTO
{
    public class CargoDateDTO
    {
        public DateTime? ShipmentDateStart { get; set; }
        public DateTime? ShipmentDateFinished { get; set; }
        [Key]
        public int CargoId { get; set; }
        public DateTime DateOfFormation { get; set; }
    }
}
