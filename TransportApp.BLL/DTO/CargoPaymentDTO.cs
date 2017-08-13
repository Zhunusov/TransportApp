using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.BLL.DTO
{
    public class CargoPaymentDTO
    {
        public bool IsCostKnown { get; set; }
        public int? SumOfPayment { get; set; }
        public int? CurrencyId { get; set; }
        public string CostUnit { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsVATApplicable { get; set; }
        [Key]
        public int CargoId { get; set; }
        public float? PrePayment { get; set; }
        public string TimeOfPayment { get; set; }     
    }
}
