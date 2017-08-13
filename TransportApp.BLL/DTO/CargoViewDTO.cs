using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.BLL.DTO
{
    public class CargoViewDTO
    {
        //Cargo
        public int CargoIdNumber { get; set; }
        public int UserIdNumber { get; set; }
        public string UserBizName { get; set; }
        public int? CityShipmentId { get; set; }
        public string CityShipmentName { get; set; }
        public int? CityArrivalId { get; set; }
        public string CityArrivalName { get; set; }
        public bool IsCargoDeactivated { get; set; }
        public string CountryShipmentISOCode2 { get; set; }
        public string CountryArrivalISOCode2 { get; set; }
        public string RegionShipmentName { get; set; }
        public string RegionArrivalName { get; set; }

        //CargoDate
        public DateTime? ShipmentDateStart { get; set; }
        public DateTime? ShipmentDateFinished { get; set; }
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
        public CargoViewDTO()
        {
            PhonesDTO = new List<PhoneDTO>();
        }
        
    }
}
