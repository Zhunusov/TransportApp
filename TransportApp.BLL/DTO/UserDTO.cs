using System.Collections.Generic;
using TransportApp.DAL.Entities;

namespace TransportApp.BLL.DTO
{
    public class UserDTO
    {     
        public int UserId { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }   
                       
    }
}
