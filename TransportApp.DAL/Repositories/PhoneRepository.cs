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
    public class PhoneRepository:IRepository<Phone>
    {
        private ApplicationContext db;
        public PhoneRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<Phone> GetAll()
        {
            return db.Phones;
        }
        public Phone Get(object obj)
        {
            return db.Phones.Find((int)obj);
        }
        public IEnumerable<Phone> Find(Func<Phone, Boolean> predicate)
        {
            return db.Phones.Where(predicate).ToList();
        }
        public bool Create(Phone item, out Phone addedItem)
        {
            addedItem = db.Phones.Add(item);
            return true;
        }
        public void Update(Phone item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Phone phone = db.Phones.Find(id);
            if (phone != null)
            {
                db.Phones.Remove(phone);
            }
        }
    }
}
