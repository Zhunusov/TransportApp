using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportApp.DAL.Entities
{
    public class Phone
    {
        public int CountryId { get; set; }
        [Key]
        public int PhoneID { get; set; }        
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public bool IsViberSupported { get; set; }        
        public string EmployeeId { get; set; }
        public bool IsWhatUpSupported { get; set; }
        public virtual Country Country { get; set; }        
        public virtual UserBizInformation UserBizInformation { get; set; }
    }
}
