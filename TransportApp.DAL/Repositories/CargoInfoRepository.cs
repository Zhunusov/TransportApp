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
    public class CargoInfoRepository:IRepository<CargoInfo>
    {
        private ApplicationContext db;
        public CargoInfoRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<CargoInfo> GetAll()
        {
            return db.CargoInfoes;
        }
        public CargoInfo Get(object obj)
        {
            return db.CargoInfoes.Find((int)obj);
        }
        public IEnumerable<CargoInfo> Find(Func<CargoInfo, Boolean> predicate)
        {
            return db.CargoInfoes.Where(predicate).ToList();
        }
        public bool Create(CargoInfo item, out CargoInfo addedItem)
        {
            addedItem = db.CargoInfoes.Add(item);
            return true;
        }
        public void Update(CargoInfo item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            CargoInfo cargoInfo = db.CargoInfoes.Find(id);
            if (cargoInfo!= null)
            {
                db.CargoInfoes.Remove(cargoInfo);
            }
        }
    }
}
