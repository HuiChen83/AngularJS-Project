using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppAngularJS.Models;

namespace WebAppAngularJS.Services
{
    public class ServiceHelper
    {
        public static string CalculateFare(Trip trip)
        {
            try
            {
                double NYSTax = 0.50;
                double Entry = 3.00;
                double BlwSpeadChargeByMiles = Convert.ToDouble(trip.MilesBlwSpeed) * 5.00 * 0.35;
                double AbvSpeedChargeByMins = Convert.ToDouble(trip.MinsAbvSpeed) * 0.35;
                double NightSurCharge = isNight(trip.Time) * 0.50;
                double PeakHourSurCharge = isPeakHour(trip.Date, trip.Time) * 1.00;

                double result = NYSTax + Entry + BlwSpeadChargeByMiles + AbvSpeedChargeByMins + NightSurCharge + PeakHourSurCharge;
                return result.ToString();
            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        //Rush Hours: Mon-Fri 16:00 to 20:00(Holiday NOT Considered)
        private static int isPeakHour(string DateStr, string TimeStr)
        {
            DateTime date = DateTime.Parse(DateStr);
            DateTime time = DateTime.Parse(TimeStr);
            int result;

            if ((date.DayOfWeek < DayOfWeek.Saturday && date.DayOfWeek > DayOfWeek.Sunday) &&
                (time.Hour < 20 && time.Hour > 16))
            { result = 1; }
            else
            { result = 0; }

            return result;
        }

        private static int isNight(string TimeStr)
        {
            DateTime time = DateTime.Parse(TimeStr);
            int result;

            if (time.Hour < 6 && time.Hour > 20)
            { result = 1; }
            else
            { result = 0; }

            return result;
        }
    }
}