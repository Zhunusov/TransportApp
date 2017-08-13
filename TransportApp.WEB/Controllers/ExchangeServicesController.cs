using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportApp.WEB.Filters;

namespace TransportApp.WEB.Controllers
{
    [Culture]
    public class ExchangeServicesController : Controller
    {
        // GET: ExchangeServices
        public ActionResult Index()
        {
            return View();
        }
    }
}