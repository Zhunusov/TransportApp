using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.DAL.Interfaces;
using TransportApp.DAL.Entities;
using TransportApp.DAL.EF;
using System.Data.Entity;

namespace TransportApp.DAL.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private ApplicationContext db;
        public CountryRepository (ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }
        public Country Get(object obj)
        {
            return db.Countries.Find((int)obj);
        }
        public IEnumerable<Country> Find(Func<Country, Boolean> predicate)
        {
            return db.Countries.Where(predicate).ToList();
        }
        public bool Create(Country country, out Country addedItem)
        {
            addedItem = db.Countries.Add(country);
            return true;
        }
        public void Update(Country country)
        {
            db.Entry(country).State = EntityState.Modified;
        }
        public void Delete(int countryId)
        {
            Country country = db.Countries.Find(countryId);
            if (country != null)
            {
                db.Countries.Remove(country);
            }
        }
    }
}
