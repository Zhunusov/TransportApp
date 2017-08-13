using System;
using System.Collections.Generic;
using TransportApp.BLL.DTO;
using System.Threading.Tasks;

namespace TransportApp.BLL.Interfaces
{
    public interface IUserService
    {
        bool RegisterUser (UserDTO userDto);
        int EditUserBizInfo(string email, UserBizInfoDTO userBizInfoDto, int cityId);
        bool ChangeAuthorizedStatus(string email, bool IsAuthorizedParam);
        UserDTO GetUser (string email, string password);
        UserDTO GetUser(string email);
        UserBizInfoDTO GetUserBizInfo(int id);
        IEnumerable<UserDTO> GetUsers();        
        void Dispose();
    }
}
