using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebService.ClassLibrary;

namespace WebService.AspNet.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {

            return View();
        }

    }
}