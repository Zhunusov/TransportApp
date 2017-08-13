using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TransportApp.DAL.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public int RoleId { get; set; }
        public virtual UserBizInformation UserBizInfo { get; set; }
        public virtual Role Role { get; set; }      

    }
}
