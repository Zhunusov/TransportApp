using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.BLL.DTO;

namespace TransportApp.BLL.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<CountryDTO> GetCoutries();
        CountryDTO GetCountry(string countryName);
        CountryDTO GetCountry(int countryId);
        IEnumerable<RegionDTO> GetRegions(int countryId);
        RegionDTO GetRegion(int regionId);
        RegionDTO GetRegion(string regionName);
        IEnumerable<CityDTO> GetCities(int countryId);
        IEnumerable<CityDTO> GetCities(int countryId, int regionId);
        CityDTO GetCity(string cityName);
        CityDTO GetCity(int cityId);
        void Dispose();
    }
}
