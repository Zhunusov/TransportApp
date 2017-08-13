using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportApp.WEB.Filters;
using TransportApp.WEB.Models;
using TransportApp.BLL.Interfaces;
using TransportApp.BLL.DTO;
using TransportApp.BLL.Infrastructure;
using AutoMapper;

namespace TransportApp.WEB.Controllers
{
    [Culture]
    public class UserAreaController : Controller
    {
        IUserService userService;
        ILocationService locationService;

        public UserAreaController(IUserService uService, ILocationService lService)
        {
            userService = uService;
            locationService = lService;
        }
        
        public ActionResult UserAccount()
        {
            return View();
        }

        
        public ActionResult RegistrationData(string returnUrl)
        {
            UserRegDataViewModel model = new UserRegDataViewModel();
            if (Request.IsAuthenticated)
            {
                var user = userService.GetUser(User.Identity.Name);
                if (user!= null)
                {
                    var userBizInfo = userService.GetUserBizInfo(user.UserId);
                    if (userBizInfo != null)
                    {
                        Mapper.Initialize(cfg =>
                        {
                            cfg.CreateMap<UserBizInfoDTO, UserRegDataViewModel>();
                        });
                        model = Mapper.Map<UserBizInfoDTO, UserRegDataViewModel>(userBizInfo);
                        if (userBizInfo.CityId != null)
                        {
                            var city = locationService.GetCity((int)userBizInfo.CityId);
                            var region = locationService.GetRegion((int)city.RegionId);
                            var coutry = locationService.GetCountry((int)city.CountryId);
                            model.CityName = city.CityName;
                            model.RegionName = region.RegionName;
                            model.CountryName = coutry.CountryName;
                        }                       
                        return PartialView(model);
                    }
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return PartialView(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationData(UserRegDataViewModel model, string returnUrl, object obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var city = locationService.GetCity(model.CityName);
                    string userEmail = User.Identity.Name;
                    if (userEmail != null && city!=null)
                    {
                        Mapper.Initialize(cfg =>
                        {
                            cfg.CreateMap<UserRegDataViewModel, UserBizInfoDTO>();
                        });
                        var userBizInfoDTO = Mapper.Map<UserRegDataViewModel, UserBizInfoDTO>(model);
                        switch (userService.EditUserBizInfo(userEmail, userBizInfoDTO, city.CityId))
                        {
                            case 0:
                                userService.ChangeAuthorizedStatus(userEmail, true);
                                HttpContext.Response.Write("<div class=\"alert alert-success\"> <strong>Success adding!</strong></div>");
                                break;

                            case 1:
                                userService.ChangeAuthorizedStatus(userEmail, true);
                                HttpContext.Response.Write("<div class=\"alert alert-success\"> <strong>Success editing!</strong></div>");
                                break;

                            case 2:
                                HttpContext.Response.Write("<div class=\"alert alert-danger\"> <strong>Danger!</strong></div>");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return Redirect("UserAccount");
        }
        

        public ActionResult CountrySearch(string term)
        {
            var countries = locationService.GetCoutries();
            if (countries != null)
            {
                var models = countries.Where(a => a.CountryName.Contains(term, StringComparison.OrdinalIgnoreCase))
                    .Select(a => new { value = a.CountryName })
                    .Distinct()
                    .OrderBy(a => a.value);

                return Json(models, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult RegionSearch(string term, string countryName)
        {
            if (countryName != null)
            {
                var country = locationService.GetCountry(countryName);
                if (country != null)
                {
                    var regions = locationService.GetRegions(country.CountryId);
                    if (regions != null)
                    {
                        var models = regions.Where(r => r.RegionName.Contains(term, StringComparison.OrdinalIgnoreCase))
                            .Select(r => new { value = r.RegionName })
                            .Distinct()
                            .OrderBy(r=> r.value);

                        return Json(models, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            
            return null;
        }

        public ActionResult CitySearch(string term, string countryName, string regionName)
        {
            if (countryName != null && regionName != null)
            {
                var country = locationService.GetCountry(countryName);
                var region = locationService.GetRegion(regionName);
                if (country != null && region!=null)
                {
                    var cities = locationService.GetCities(country.CountryId, region.RegionId);
                    if (cities != null)
                    {
                        var models = cities.Where(c => c.CityName.Contains(term, StringComparison.OrdinalIgnoreCase))
                            .Select(c => new { value = c.CityName })
                            .Distinct()
                            .OrderBy(c=>c.value);

                        return Json(models, JsonRequestBehavior.AllowGet);
                    }
                    
                }
            }
            return null;
        }

        public ActionResult CountrySelected(string countryName)
        {
            return null;
        }
    }

}