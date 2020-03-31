using System.Web.Mvc;
using WebAppAngularJS.Models;

namespace WebAppAngularJS.Controllers
{
    public interface ITripController
    {
        JsonResult FareCalculate(Trip trip);
    }
}