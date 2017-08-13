using System;
using System.Collections.Generic;
using System.Linq;
using TransportApp.DAL.Interfaces;
using TransportApp.DAL.Entities;
using TransportApp.DAL.EF;
using System.Data.Entity;
using System.Threading.Tasks;

namespace TransportApp.DAL.Repositories
{
    public class UserProfileRepository : IRepository<UserBizInformation>
    {
        private ApplicationContext _db;

        public UserProfileRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<UserBizInformation> GetAll()
        {
            return _db.UserBizInformations;
        }

        public UserBizInformation Get(object obj)
        {
            return _db.UserBizInformations
                .Find((int)obj);
        }

        public bool Create(UserBizInformation profile, out UserBizInformation addedItem)
        {
            addedItem = _db.UserBizInformations.Add(profile);
            return true;
        }

        public void Update(UserBizInformation profile)
        {
            var u = _db.UserBizInformations.Find(profile.UserId);
            if (u != null)
            {
                u.UserId = profile.UserId;
                u.Address = profile.Address;
                u.BizDescription = profile.BizDescription;
                u.BizName = profile.BizName;
                u.BizStatus = profile.BizStatus;
                u.BizUniqueNumber = profile.BizUniqueNumber;
                u.IsAuthorized = profile.IsAuthorized;
                u.CityId = profile.CityId;
            }
        }

        public IEnumerable<UserBizInformation> Find(Func<UserBizInformation, Boolean> predicate)
        {
            return _db.UserBizInformations.Where(predicate).ToList();
        }

        public void Delete(int userId)
        {
            Task<UserBizInformation> profile = _db.UserBizInformations.FindAsync(userId);
            if (profile != null)
            {
                _db.UserBizInformations.Remove(profile.Result);
            }
        }
    }
}
