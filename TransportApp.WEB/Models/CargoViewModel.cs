using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransportApp.BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.WEB.Models
{
    public class CargoSeachResultViewModel
    {
        //Cargo               
        public string UserBizName { get; set; }        
        public string CityShipmentName { get; set; }       
        public string CityArrivalName { get; set; }
        public string CountryShipmentISOCode2 { get; set; }
        public string CountryArrivalISOCode2 { get; set; }
        public string RegionShipmentName { get; set; }
        public string RegionArrivalName { get; set; }

        //CargoDate
        public DateTime ShipmentDateStart { get; set; }
        public DateTime ShipmentDateFinished { get; set; }
        public DateTime DateOfFormation { get; set; }

        //CargoInfo
        public string Name { get; set; }
        public string ADR { get; set; }
        public decimal? Length { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal WeightMin { get; set; }
        public decimal WeightMax { get; set; }
        public int? SizeMin { get; set; }
        public int? SizeMax { get; set; }
        public string AdditionalInfo { get; set; }
        public float? RequiredCountOfTransport { get; set; }
        public string CargoFrequency { get; set; }

        //CargoPayment
        public bool IsCostKnown { get; set; }
        public int? SumOfPayment { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencySymbol { get; set; }
        public string CostUnit { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsVATApplicable { get; set; }
        public float? PrePayment { get; set; }
        public string TimeOfPayment { get; set; }

        public List<PhoneDTO> PhonesDTO { get; set; }
        public CargoSeachResultViewModel()
        {
            PhonesDTO = new List<PhoneDTO>();
        }
        
    }

    public class CargoFilterModel
    {        
        [Required]
        public string CoutriesArr { get; set; }
        public string RegionsArr { get; set; }
        public string CitiesArr { get; set; }
        [Required]
        public string CoutriesDest { get; set; }
        public string RegionsDest { get; set; }
        public string CitiesDest { get; set; }

        
        public DateTime DatePikerBegin { get; set; }
        public DateTime DatePikerEnd { get; set; }


        public decimal WeightMin { get; set; }
        public decimal WeightMax { get; set; }
        public int CapacityMin { get; set; }
        public int CapacityMax { get; set; }





    }

}