using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using TransportApp.WEB.Models;
using TransportApp.WEB.Filters;
using AutoMapper;
using TransportApp.BLL.DTO;
using TransportApp.BLL.Interfaces;
using TransportApp.BLL.Infrastructure;
using System.Web.Security;

namespace TransportApp.WEB.Controllers
{
    [Culture]
    public class AccountController : Controller
    {
        IUserService userService;
        public AccountController(IUserService service)
        {
            userService = service;
        }
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
                
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Mapper.Initialize(cfg => {
                        cfg.CreateMap<RegisterViewModel, UserDTO>()
                        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
                        });
                    var userDto = Mapper.Map<RegisterViewModel, UserDTO>(model);
                    if (userService.RegisterUser(userDto))
                    {
                        //ViewBag.UserName = userDto.UserName;
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("SuccessfulRegistration", "Account");                        
                    }
                    return View(model);
                }
                catch(ValidationException ex)
                {
                    if (string.Compare(ex.Property, "Resource")==0)
                    {
                        switch (ex.Message)
                        {
                            case "UserEmailExisted": 
                                ModelState.AddModelError("", Resources.Resource.UserEmailExisted);
                                break;
                        }
                    }
                    
                }
                               
            }
                        
            return View(model);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Поиск пользователя в базе
                    UserDTO userDto = null;
                    userDto = userService.GetUser(model.Email, model.Password);
                    if (userDto != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }                    
                    return View(model);
                }
                catch (ValidationException ex)
                {
                    if (string.Compare(ex.Property, "Resource") == 0)
                    {
                        switch (ex.Message)
                        {
                            case "EmailExceptionUnknown":
                                ModelState.AddModelError("", Resources.Resource.EmailExceptionUnknown);
                                break;

                            case "UserExceptionNotFound":
                                ModelState.AddModelError("", Resources.Resource.UserExceptionNotFound);
                                break;

                            case "PasswordExceptionIncorrect":
                                ModelState.AddModelError("", Resources.Resource.PasswordExceptionIncorrect);
                                break;
                        }
                    }
                }
            }
            return View(model);            
        }

        //
        // POST: /Account/LogOff
        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/SuccessfulRegistration       
        
        public ActionResult SuccessfulRegistration()
        {
            return View();
        }
        
        
    }
}