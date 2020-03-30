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
                trip.MinsAbvSpeed = !string.IsNullOrEmpty(trip.MinsAbvSpeed) ? trip.MinsAbvSpeed : "0";
                trip.MilesBlwSpeed = !string.IsNullOrEmpty(trip.MilesBlwSpeed) ? trip.MilesBlwSpeed : "0";

                double NYSTax = 0.50;
                double Entry = 3.00;
                double BlwSpeadChargeByMiles = Convert.ToDouble(trip.MilesBlwSpeed) * 5.00 * 0.35;
                double AbvSpeedChargeByMins = Convert.ToDouble(trip.MinsAbvSpeed) * 0.35;
                double NightSurCharge = IsNight(trip.DateTime) * 0.50;
                double PeakHourSurCharge = IsPeakHour(trip.DateTime) * 1.00;

                double result = NYSTax + Entry + BlwSpeadChargeByMiles + AbvSpeedChargeByMins + NightSurCharge + PeakHourSurCharge;

                return result.ToString();
            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        //Rush Hours: Mon-Fri 16:00 to 20:00(Holiday NOT Considered)
        private static int IsPeakHour(string DateTimeStr)
        {
            DateTime dateTime = DateTime.Parse(DateTimeStr);

            TimeSpan peakStart = new TimeSpan(16, 0, 0); //16:00
            TimeSpan peakEnd = new TimeSpan(20, 0, 0);  //20:00

            int result;

            if ((dateTime.DayOfWeek > DayOfWeek.Sunday && dateTime.DayOfWeek < DayOfWeek.Saturday)  //Workday
                && (dateTime.TimeOfDay > peakStart && dateTime.TimeOfDay < peakEnd))    //PeakHour
            { result = 1; }
            else
            { result = 0; }

            return result;
        }

        private static int IsNight(string DateTimeStr)
        {
            DateTime dateTime = DateTime.Parse(DateTimeStr);

            TimeSpan nightStart = new TimeSpan(20, 0, 0); //20:00
            TimeSpan nightEnd = new TimeSpan(6, 0, 0);//06:00

            int result;

            if (dateTime.TimeOfDay > nightStart || dateTime.TimeOfDay < nightEnd)
            { result = 1; }
            else
            { result = 0; }

            return result;
        }
    }
}