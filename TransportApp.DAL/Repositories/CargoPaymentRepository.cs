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
    public class CargoPaymentRepository:IRepository<CargoPayment>
    { 
        private ApplicationContext db;
        public CargoPaymentRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<CargoPayment> GetAll()
        {
            return db.CargoPayments;
        }
        public CargoPayment Get(object obj)
        {
            return db.CargoPayments.Find((int)obj);
        }
        public IEnumerable<CargoPayment> Find(Func<CargoPayment, Boolean> predicate)
        {
            return db.CargoPayments.Where(predicate).ToList();
        }
        public bool Create(CargoPayment item, out CargoPayment addedItem)
        {
            addedItem = db.CargoPayments.Add(item);
            return true;
        }
        public void Update(CargoPayment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            CargoPayment cargoPayment = db.CargoPayments.Find(id);
            if (cargoPayment != null)
            {
                db.CargoPayments.Remove(cargoPayment);
            }
        }
    }
}
