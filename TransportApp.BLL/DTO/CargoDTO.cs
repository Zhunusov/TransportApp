using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.BLL.DTO
{
    public class CargoDTO
    {
        public int UserId { get; set; }
        public int? CityShipmentId { get; set; }
        [Key]
        public int CargoId { get; set; }
        public int? CityArrivalId { get; set; }
        public bool IsCargoDeactivated { get; set; }
    }
}
