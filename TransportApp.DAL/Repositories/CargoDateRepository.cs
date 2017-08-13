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
    public class CargoDateRepository:IRepository<CargoDate>
    {
        private ApplicationContext db;
        public CargoDateRepository (ApplicationContext context)
        {
            db = context;
        }
        public  IEnumerable<CargoDate> GetAll()
        {
            return db.CargoDates;
        }
        public CargoDate Get(object obj)
        {
            return db.CargoDates.Find((int)obj);
        }
        public IEnumerable<CargoDate> Find(Func<CargoDate, Boolean> predicate)
        {
            return db.CargoDates.Where(predicate).ToList();
        }
        public bool Create(CargoDate item, out CargoDate addedItem)
        {
            addedItem = db.CargoDates.Add(item);
            return true;
        }
        public void Update(CargoDate item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            CargoDate cargoDate = db.CargoDates.Find(id);
            if (cargoDate != null)
                db.CargoDates.Remove(cargoDate);
        }
    }
}
