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
    public class CurrencyRepository:IRepository<Currency>
    {
        private ApplicationContext db;
        public CurrencyRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<Currency> GetAll()
        {
            return db.Currencies;
        }
        public Currency Get(object obj)
        {
            return db.Currencies.Find((int)obj);
        }
        public IEnumerable<Currency> Find(Func<Currency, Boolean> predicate)
        {
            return db.Currencies.Where(predicate).ToList();
        }
        public bool Create(Currency item, out Currency addedItem)
        {
            addedItem = db.Currencies.Add(item);
            return true;
        }
        public void Update(Currency item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency != null)
            {
                db.Currencies.Remove(currency);
            }
        }
    }
}
