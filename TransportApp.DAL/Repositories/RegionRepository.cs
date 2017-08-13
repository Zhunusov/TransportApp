using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.DAL.EF;
using TransportApp.DAL.Entities;
using TransportApp.DAL.Interfaces;
using System.Data.Entity;

namespace TransportApp.DAL.Repositories
{
    public class RegionRepository : IRepository<Region>
    {
        private ApplicationContext db;
        public RegionRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<Region> GetAll()
        {
            return db.Regions.Include(r => r.Country);
        }
        public Region Get(object regionId)
        {
            return db.Regions.Find((int)regionId);
        }
        public IEnumerable<Region> Find(Func<Region, Boolean> predicate)
        {
            return db.Regions.Include(r => r.Country).Where(predicate).ToList();
        }
        public bool Create(Region region, out Region addedItem)
        {
            addedItem = db.Regions.Add(region);
            return true;
        }
        public void Update(Region region)
        {
            db.Entry(region).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            Region region = db.Regions.Find(id);
            if (region != null)
            {
                db.Regions.Remove(region);
            }
        }
    }
}
