using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAngularJS.Models;
using WebAppAngularJS.Services;

namespace WebAppAngularJS.Controllers
{
    public class TripController : Controller
    {
        private CrudContext _context = null;
        // GET: Trip
        public TripController()
        {
            _context = new CrudContext();
        }

        public JsonResult FareCalculate(Trip trip)
        {
            string Result = ServiceHelper.CalculateFare(trip);
            return Json(Result);
        }
    }
}