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
    public class RoleRepository : IRepository<Role>
    {
        private ApplicationContext _db;

        public RoleRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _db.Roles;                
        }

        public Role Get(object obj)
        {
            return _db.Roles
                .Where(r=>r.Name==(string)obj)
                .FirstOrDefault();
        }

        public bool Create(Role role, out Role addedItem)
        {
            addedItem = _db.Roles.Add(role);
            return true;
        }

        public void Update(Role role)
        {
            _db.Entry(role).State = EntityState.Modified;
        }

        public IEnumerable<Role> Find(Func<Role, Boolean> predicate)
        {
            return _db.Roles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Task<Role> role = _db.Roles.FindAsync(id);
            if (role != null)
            {
                _db.Roles.Remove(role.Result);
            }
        }
    }
}
