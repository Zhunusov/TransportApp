using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.BLL.DTO
{
    public class CargoInfoDTO
    {
        public string Name { get; set; }
        [Key]
        public int CargoId { get; set; }
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
    }
}
