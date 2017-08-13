using System;
using System.Collections.Generic;
using System.Linq;
using TransportApp.DAL.Interfaces;
using TransportApp.DAL.Entities;
using TransportApp.DAL.EF;
using TransportApp.DAL.Infrastructure;
using System.Data.Entity;
using System.Threading.Tasks;


namespace TransportApp.DAL.Repositories
{
    public class UserRepository :IRepository<User>
    {
        private ApplicationContext _db;

        public UserRepository (ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<User> GetAll()
        {            
            return _db.Users;
        }

        public User Get(object obj)
        {
            return _db.Users
                .Where(u=> u.Email== (string)obj)
                .FirstOrDefault();
        }

        public bool Create (User user, out User addedItem)
        {
            var res = _db.Users.Where(u => u.Email == user.Email);
            if (res.Count() == 0)
            {
                addedItem = _db.Users.Add(user);
                return true;
            }                
            else
            {
                throw new DatabaseValidationException("UserEmailExisted", "Resource");                
            }
            
        }

        public void Update (User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find (Func<User, Boolean> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        public void Delete (int id)
        {
            Task<User> user = _db.Users.FindAsync(id);
            if(user != null)
            {
                _db.Users.Remove(user.Result);
            }
        }
    }
}
