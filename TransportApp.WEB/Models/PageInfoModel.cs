using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportApp.WEB.Models
{
    public class PageInfo
    {
        public int PadeNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }

    public class PageCargoViewModel
    {
        public IEnumerable<CargoSeachResultViewModel> Cargoes { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}