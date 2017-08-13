using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TransportApp.DAL.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }

}
