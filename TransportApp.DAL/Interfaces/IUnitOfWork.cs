using System;
using TransportApp.DAL.Entities;
using System.Threading.Tasks;

namespace TransportApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<UserBizInformation> UserBizInfo { get; }
        IRepository<Country> Countries { get; }
        IRepository<Region> Regions { get; }
        IRepository<City> Cities { get; }
        IRepository<Currency> Currencies { get; }
        IRepository<Phone> Phones { get; }
        IRepository<Cargo> Cargoes { get; }
        IRepository<CargoInfo> CargoInfoes { get; }
        IRepository<CargoPayment> CargoPayments { get; }
        IRepository<CargoDate> CargoDates { get; }
        void Save();
    }
}
