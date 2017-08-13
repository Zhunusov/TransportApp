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
    public class CargoRepository : IRepository<Cargo>
    {
        private ApplicationContext db;
        public CargoRepository(ApplicationContext context)
        {
            db = context;
        }
        public IEnumerable<Cargo> GetAll()
        {
            return db.Cargoes;
        }
        public Cargo Get(object obj)
        {
            return db.Cargoes.Find((int)obj);
        }
        public IEnumerable<Cargo> Find(Func<Cargo, Boolean> predicate)
        {
            return db.Cargoes.Where(predicate).ToList();
        }
        public bool Create(Cargo item, out Cargo addedItem)
        {
            addedItem = db.Cargoes.Add(item);
            return true;
        }
        public void Update(Cargo item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Cargo cargo = db.Cargoes.Find(id);
            if(cargo != null)
            {
                db.Cargoes.Remove(cargo);
            }
        }
    }
}
