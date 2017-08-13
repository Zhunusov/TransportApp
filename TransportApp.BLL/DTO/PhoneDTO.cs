using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.BLL.DTO
{
    public class PhoneDTO
    {
        public int CountryId { get; set; }
        [Key]
        public int PhoneID { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public bool IsViberSupported { get; set; }
        public string EmployeeId { get; set; }
        public bool IsWhatUpSupported { get; set; }       
    }
}
