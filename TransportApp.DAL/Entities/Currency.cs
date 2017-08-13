using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace TransportApp.DAL.Entities
{
    public class Currency
    {    
        public string CurrencyName { get; set; }
        [Key]
        public int CurrencyId { get; set; }        
        public string ISOCode3 { get; set; }        
        public string Symbol { get; set; }
    }
}
