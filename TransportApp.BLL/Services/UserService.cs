using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportApp.BLL.DTO;
using TransportApp.BLL.Infrastructure;
using TransportApp.DAL.Entities;
using TransportApp.BLL.Interfaces;
using TransportApp.DAL.Interfaces;
using TransportApp.DAL.Infrastructure;
using AutoMapper;

namespace TransportApp.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService (IUnitOfWork uow)
        {
            Database = uow;
        }

        public bool RegisterUser(UserDTO userDto)
        {
            try
            {
                User createdUser;            
                UserDTO user = new UserDTO
                {
                    Email = userDto.Email,
                    UserName = userDto.Email,
                    Password = userDto.Password,
                    RoleId = 2                    
                };

                Mapper.Initialize(cfg => {
                    cfg.CreateMap<UserDTO, User>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
                });

                if(Database.Users.Create(Mapper.Map<UserDTO, User>(user), out createdUser))
                {   
                    Database.Save();
                    return true;
                }
                return false;                
            }
            catch(DatabaseValidationException ex)
            {
                throw new ValidationException(ex.Message, ex.Property);                
            }              
                       
        }

        public int EditUserBizInfo(string email, UserBizInfoDTO userBizInfoDto, int cityId)
        {
            try
            {
                UserBizInformation createdUserBizInformation;
                var user = Database.Users.Get(email);
                if (user != null)
                {
                    UserBizInfoDTO userBizInfo = new UserBizInfoDTO
                    {
                        UserId = user.UserId,
                        Address = userBizInfoDto.Address,
                        BizDescription = userBizInfoDto.BizDescription,
                        BizName = userBizInfoDto.BizName,
                        BizStatus = userBizInfoDto.BizStatus,
                        BizUniqueNumber = userBizInfoDto.BizUniqueNumber,
                        CityId = cityId
                    };

                    Mapper.Initialize(cfg => {
                        cfg.CreateMap<UserBizInfoDTO, UserBizInformation>();
                    });

                    if(Database.UserBizInfo.Get(userBizInfo.UserId) == null)
                    {
                        if (Database.UserBizInfo.Create(Mapper.Map<UserBizInfoDTO, UserBizInformation>(userBizInfo), out createdUserBizInformation))
                        {
                            Database.Save();
                            return 0;//Внесение новой записи в базу
                        }
                    }
                    else
                    {
                        Database.UserBizInfo.Update(Mapper.Map<UserBizInfoDTO, UserBizInformation>(userBizInfo));
                        Database.Save();
                        return 1;//Изменение записи в базе
                    }
                    
                }
                return 2;//Неудачная попытка добавить информацию в базу
            }
            catch (DatabaseValidationException ex)
            {
                throw new ValidationException(ex.Message, ex.Property);
            }
            
        }
        public UserDTO GetUser(string email, string password)
        {            
            if (email == null)
                throw new ValidationException("EmailExceptionUnknown", "Resource");
            var user = Database.Users.Get(email);

            if (user == null)
                throw new ValidationException("UserExceptionNotFound", "Resource");

            if (string.Compare(user.PasswordHash, password) != 0)
                throw new ValidationException("PasswordExceptionIncorrect", "Resource");            

            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            return Mapper.Map<User, UserDTO>(user);
        }

        public UserDTO GetUser(string email)
        {
            if (email != null)
            {
                var user = Database.Users.Get(email);

                if (user != null)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
                    return Mapper.Map<User, UserDTO>(user);
                }  
            }
            return null;  
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
                });
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public bool ChangeAuthorizedStatus(string email, bool IsAuthorizedParam)
        {
            try
            {
                var user = Database.Users.Get(email);
                if (user != null)
                {
                    var userBizInfo = Database.UserBizInfo.Get(user.UserId);
                    if (userBizInfo != null)
                    {
                        userBizInfo.IsAuthorized = IsAuthorizedParam;
                        Database.UserBizInfo.Update(userBizInfo);
                        Database.Save();
                        return true;
                    }
                }
                return false;
            }
            catch (DatabaseValidationException ex)
            {
                throw new ValidationException(ex.Message, ex.Property);
            }
        }
        public UserBizInfoDTO GetUserBizInfo(int id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserBizInformation, UserBizInfoDTO>();
            });
            return Mapper.Map<UserBizInformation,UserBizInfoDTO>(Database.UserBizInfo.Get(id));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
