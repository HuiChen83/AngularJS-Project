using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAngularJS.Models;
using WebAppAngularJS.Services;

namespace WebAppAngularJS.Controllers
{
    public class TripController : Controller, ITripController
    {
        public JsonResult FareCalculate(Trip trip)
        {
            ServiceHelper helper = new ServiceHelper();
            string Result = helper.CalculateFare(trip);
            return Json(Result);
        }
    }
}