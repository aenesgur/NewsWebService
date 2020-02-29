using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WebService.AspNet.Mvc.Models;
using WebService.ClassLibrary;

namespace WebService.AspNet.Mvc.Controllers
{
    public class BigParaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}