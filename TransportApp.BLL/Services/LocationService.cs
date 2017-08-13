using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.BLL.DTO;
using TransportApp.BLL.Interfaces;
using TransportApp.DAL.Interfaces;
using AutoMapper;
using TransportApp.DAL.Entities;

namespace TransportApp.BLL.Services
{
    public class LocationService: ILocationService
    {
        IUnitOfWork Database { get; set; }
        public LocationService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<CountryDTO> GetCoutries()
        {
            var countries = Database.Countries.GetAll();
            if (countries != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
                return Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(countries);
            }
            return null;
        }
        public CountryDTO GetCountry(string countryName)
        {
            var country = Database.Countries
                .Find(c => c.CountryName == countryName)
                .FirstOrDefault();
                
            if (country != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
                return Mapper.Map<Country, CountryDTO>(country);
            }
            return null;
        }

        public CountryDTO GetCountry(int countryId)
        {
            var country = Database.Countries.Get(countryId);
            if (country != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
                return Mapper.Map<Country, CountryDTO>(country);
            }
            return null;
        }
        public IEnumerable<RegionDTO> GetRegions(int countryId)
        {
            var regions = Database.Regions.Find(c => c.CountryId == countryId);
            if (regions != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Region, RegionDTO>());
                return Mapper.Map<IEnumerable<Region>, List<RegionDTO>>(regions);
            }
            return null;
        }
        public RegionDTO GetRegion(int regionId)
        {
            var region = Database.Regions.Get(regionId);
            if (region != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Region, RegionDTO>());
                return Mapper.Map<Region, RegionDTO>(region);
            }
            return null;
        }
        public RegionDTO GetRegion(string regionName)
        {
            var region = Database.Regions
                .Find(r => r.RegionName == regionName)
                .FirstOrDefault();
            if (region != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Region, RegionDTO>());
                return Mapper.Map<Region, RegionDTO>(region);
            }
            return null;
        }
        public IEnumerable<CityDTO> GetCities(int countryId)
        {
            var cities = Database.Cities.Find(c => c.CountryId == countryId);
            if (cities != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<City, CityDTO>());
                return Mapper.Map<IEnumerable<City>, List<CityDTO>>(cities);
            }
            return null;
        }
        public IEnumerable<CityDTO> GetCities(int countryId, int regionId)
        {
            var cities = Database.Cities.Find(c => c.CountryId == countryId && c.RegionId == regionId);
            if(cities != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<City, CityDTO>());
                return Mapper.Map<IEnumerable<City>, List<CityDTO>>(cities);
            }
            return null;
        }
        public CityDTO GetCity(string cityName)
        {
            var city = Database.Cities
                .Find(c=>c.CityName==cityName)
                .FirstOrDefault();
            if (city != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<City, CityDTO>());
                return Mapper.Map<City, CityDTO>(city);
            }
            return null;

        }
        public CityDTO GetCity(int cityId)
        {
            var city = Database.Cities.Get(cityId);
            if (city != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<City, CityDTO>());
                return Mapper.Map<City, CityDTO>(city);
            }
            return null;

        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
