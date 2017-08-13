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
    public class CityRepository : IRepository<City>
    {
        private ApplicationContext db;
        public CityRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<City> GetAll()
        {
            return db.Cities.Include(c => c.Region);
        }
        public City Get(object cityId)
        {
            return db.Cities.Find(cityId);
        }
        public IEnumerable<City> Find(Func<City, Boolean> predicate)
        {
            return db.Cities.Include(c => c.Region).Where(predicate).ToList();
        }
        public bool Create(City city, out City addedItem)
        {
            addedItem = db.Cities.Add(city);
            return true;
        }
        public void Update(City city)
        {
            db.Entry(city).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(int id)
        {
            City city = db.Cities.Find(id);
            if (city != null)
            {
                db.Cities.Remove(city);
            }
        }
    }
}
