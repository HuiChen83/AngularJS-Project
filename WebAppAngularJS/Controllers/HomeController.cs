using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using WebAppAngularJS.Models;
using WebAppAngularJS.Services;

namespace WebAppAngularJS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Get: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Page1()
        {
            return View();
        }
    }
}