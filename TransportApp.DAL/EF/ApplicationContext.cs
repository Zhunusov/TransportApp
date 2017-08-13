using System.Data.Entity;
using TransportApp.DAL.Entities;
using System.Threading.Tasks;

namespace TransportApp.DAL.EF
{
    public class ApplicationContext : DbContext
    {        
        public ApplicationContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer<ApplicationContext>(null);
        }
        public virtual DbSet<UserBizInformation> UserBizInformations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Union> Unions { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<CargoInfo> CargoInfoes { get; set; }
        public virtual DbSet<CargoPayment> CargoPayments { get; set; }
        public virtual DbSet<CargoDate> CargoDates { get; set; }

    }
}
