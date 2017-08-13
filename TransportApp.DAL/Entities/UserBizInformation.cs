using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportApp.DAL.Entities
{
    public class UserBizInformation
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public bool IsAuthorized { get; set; }
        public string BizUniqueNumber { get; set; }
        public string Address { get; set; }
        public string BizStatus { get; set; }
        public string BizDescription { get; set; }
        public string BizName { get; set; }
        public int? CityId { get; set; }

        public virtual User User { get; set; }
    }
}
