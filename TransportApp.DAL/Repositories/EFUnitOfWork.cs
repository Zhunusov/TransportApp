using System;
using TransportApp.DAL.Interfaces;
using TransportApp.DAL.Entities;
using TransportApp.DAL.EF;
using System.Threading.Tasks;

namespace TransportApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private UserProfileRepository _userProfileRepository;
        private CountryRepository _countryRepository;
        private RegionRepository _regionRepository;
        private CityRepository _cityRepository;
        private CurrencyRepository _currencyRepository;
        private PhoneRepository _phoneRepository;
        private CargoRepository _cargoRepository;
        private CargoInfoRepository _cargoInfoRepository;
        private CargoPaymentRepository _cargoPaymentRepository;
        private CargoDateRepository _cargoDateRepository;

        public EFUnitOfWork (string connectionString)
        {
            _db = new ApplicationContext(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);

                return _userRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_db);

                return _roleRepository;
            }
        }

        public IRepository<UserBizInformation> UserBizInfo
        {
            get
            {
                if (_userProfileRepository == null)
                    _userProfileRepository = new UserProfileRepository(_db);

                return _userProfileRepository;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new CountryRepository(_db);

                return _countryRepository;
            }
        }

        public IRepository<Region> Regions
        {
            get
            {
                if (_regionRepository == null)
                    _regionRepository = new RegionRepository(_db);

                return _regionRepository;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository(_db);

                return _cityRepository;
            }
        }

        public IRepository<Currency> Currencies
        {
            get
            {
                if (_currencyRepository == null)
                    _currencyRepository = new CurrencyRepository(_db);

                return _currencyRepository;
            }
        }
        public IRepository<Phone> Phones
        {
            get
            {
                if (_phoneRepository == null)
                    _phoneRepository = new PhoneRepository(_db);

                return _phoneRepository;
            }
        }

        public IRepository<Cargo> Cargoes
        {
            get
            {
                if (_cargoRepository == null)
                    _cargoRepository = new CargoRepository(_db);

                return _cargoRepository;
            }
        }

        public IRepository<CargoInfo> CargoInfoes
        {
            get
            {
                if (_cargoInfoRepository == null)
                    _cargoInfoRepository = new CargoInfoRepository(_db);

                return _cargoInfoRepository;
            }
        }

        public IRepository<CargoPayment> CargoPayments
        {
            get
            {
                if (_cargoPaymentRepository == null)
                    _cargoPaymentRepository = new CargoPaymentRepository(_db);

                return _cargoPaymentRepository;
            }
        }

        public IRepository<CargoDate> CargoDates
        {
            get
            {
                if (_cargoDateRepository == null)
                    _cargoDateRepository = new CargoDateRepository(_db);

                return _cargoDateRepository;
            }
        }

        public void Save()
        {
           _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose (bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
