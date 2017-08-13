using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.DAL.Entities
{
    public class Cargo
    {        
        public int UserId { get; set; }
        public int? CityShipmentId { get; set; }
        [Key]
        public int CargoId { get; set; }
        public int? CityArrivalId { get; set; }
        public bool IsCargoDeactivated { get; set; }
        public virtual CargoDate CargoDate { get; set; }
        public virtual CargoInfo CargoInfo { get; set; }
        public virtual CargoPayment CargoPayment { get; set; }       
        public virtual User User { get; set; }
        public virtual ICollection<CargoDocument> CargoDocuments { get; set; }
        public virtual ICollection<CargoImage> CargoImages { get; set; }         
        public virtual ICollection<CargoTransport> CargoTransports { get; set; }
        public Cargo()
        {
            CargoDocuments = new HashSet<CargoDocument>();
            CargoImages = new HashSet<CargoImage>();
            CargoTransports = new HashSet<CargoTransport>();
        }


    }
}
