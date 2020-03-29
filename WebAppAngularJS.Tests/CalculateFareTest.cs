using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAppAngularJS.Models;

namespace WebAppAngularJS.Tests
{
    [TestClass]
    public class CalculateFareTest
    {
        [TestMethod]
        public void Test_CalculateFare()
        {
            //Arrange
            Trip trip = new Trip {
                MinsAbvSpeed = "5",
                MilesBlwSpeed = "2",
                DateTime = "2010 - 10 - 08T21:30:00.000Z"
            };

            string expected = "9.75";

            //Act
            string actual = WebAppAngularJS.Services.ServiceHelper.CalculateFare(trip);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
