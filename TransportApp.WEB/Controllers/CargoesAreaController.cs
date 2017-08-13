using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportApp.WEB.Filters;
using TransportApp.BLL.Interfaces;
using TransportApp.BLL.DTO;
using TransportApp.WEB.Models;
using AutoMapper;

namespace TransportApp.WEB.Controllers
{
    [Culture]
    public class CargoesAreaController : Controller
    {
        ILocationService locationService;
        ICargoService cargoService;

        public CargoesAreaController(ILocationService lService, ICargoService cService)
        {
            locationService = lService;
            cargoService = cService;
        }
        // GET: CargoesArea
        [AllowAnonymous]
        public ActionResult Index()
        {            
            var countries = locationService.GetCoutries();
            var cName = new List<string>();
            foreach(var c in countries)
            {
                cName.Add(c.CountryName);
            }
            ViewBag.Countries = cName;

            List<int> weight = new List<int>();
            for (int i = 0; i<=20; i++)
            {
                weight.Add(i);
            }
            ViewBag.Weight = weight;

            List<int> capacity = new List<int>();
            for (int i = 0; i <= 20; i++)
            {
                capacity.Add(i);
            }
            for(int i = 25; i<=120; i += 5)
            {
                capacity.Add(i);
            }
            ViewBag.Capacity = capacity;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CargoSearchResult(CargoFilterModel model)
        {
            var cargoes = cargoService.GetCargoes(countryArr:model.CoutriesArr, countryDest:model.CoutriesDest,
                regArr:model.RegionsArr, regDest:model.RegionsDest, cityArr:model.CitiesArr,
                cityDest:model.CitiesDest, dateStart:model.DatePikerBegin,dateFin:model.DatePikerEnd,
                weightMin:model.WeightMin, weightMax:model.WeightMax,capMin:model.CapacityMin, capMax:model.CapacityMax);
            if (cargoes.Count() <= 0)
            {
                return HttpNotFound();
            }
            Mapper.Initialize(cfg => cfg.CreateMap<CargoViewDTO, CargoSeachResultViewModel>());
            var cRes = Mapper.Map<IEnumerable<CargoViewDTO>, List<CargoSeachResultViewModel>>(cargoes);
            
            return PartialView(cRes);
        }

        [AllowAnonymous]
        public ActionResult SelectingRegions(string countryName)
        {
            if(countryName!= null)
            {
                var country = locationService.GetCountry(countryName);
                if(country!= null)
                {
                    var regions = locationService.
                        GetRegions(country.CountryId)
                        .Select(r => new {value = r.RegionName })
                        .OrderBy(r=>r.value);

                    return Json(regions, JsonRequestBehavior.AllowGet);                    
                }
            }
            return null;
        }

        [AllowAnonymous]
        public ActionResult SelectingCities (string countryName, string regionName)
        {
            if(countryName!= null && regionName != null)
            {
                var country = locationService.GetCountry(countryName);
                var region = locationService.GetRegion(regionName);
                var cities = locationService
                    .GetCities(country.CountryId, region.RegionId)
                    .Select(c => new { value = c.CityName })
                    .OrderBy(c => c.value);

                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        
    }
}