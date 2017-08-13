using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransportApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(object obj);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        bool Create(T item, out T addedItem);
        void Update(T item);
        void Delete(int id);
    }
}
