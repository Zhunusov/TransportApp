using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportApp.DAL.Entities
{
    public class CargoPayment
    {
        public bool IsCostKnown { get; set; }
        public int? SumOfPayment { get; set; }
        public int? CurrencyId { get; set; }        
        public string CostUnit { get; set; }        
        public string PaymentMethod { get; set; }
        public bool IsVATApplicable { get; set; }
        [Key]
        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        public float? PrePayment { get; set; }        
        public string TimeOfPayment { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
