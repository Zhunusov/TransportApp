using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.BLL.DTO
{
    public class UserBizInfoDTO
    {
        public int UserId { get; set; }
        public bool IsAuthorized { get; set; }
        public string BizUniqueNumber { get; set; }
        public string Address { get; set; }
        public string BizStatus { get; set; }
        public string BizDescription { get; set; }
        public string BizName { get; set; }
        public int? CityId { get; set; }
    }
}
