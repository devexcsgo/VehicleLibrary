using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleLibrary;
using System;

namespace VehicleLibrary.Tests
{
    [TestClass()]
    public class VehicleTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                Price = 20000
            };
            var expected = "Id: 1, Brand: Toyota, Model: Corolla, Year: 2020, Price: 20000";
            Assert.AreEqual(expected, vehicle.ToString());
        }

        [TestMethod()]
        public void ValidateBrandTest()
        {
            var vehicle = new Vehicle { Brand = "To" };
            vehicle.ValidateBrand(); // Should not throw an exception

            vehicle.Brand = "T";
            Assert.ThrowsException<Exception>(() => vehicle.ValidateBrand(), "Brand must be at least 2 characters long");

            vehicle.Brand = null;
            Assert.ThrowsException<Exception>(() => vehicle.ValidateBrand(), "Brand must be at least 2 characters long");
        }

        [TestMethod()]
        public void ValidateModelTest()
        {
            var vehicle = new Vehicle { Model = "Co" };
            vehicle.ValidateModel(); // Should not throw an exception

            vehicle.Model = "C";
            Assert.ThrowsException<Exception>(() => vehicle.ValidateModel(), "Model must be at least 2 characters long");

            vehicle.Model = null;
            Assert.ThrowsException<Exception>(() => vehicle.ValidateModel(), "Model must be at least 2 characters long");
        }

        [TestMethod()]
        public void ValidateYearTest()
        {
            var vehicle = new Vehicle { Year = 2000 };
            vehicle.ValidateYear(); // Should not throw an exception

            vehicle.Year = 1899;
            Assert.ThrowsException<Exception>(() => vehicle.ValidateYear(), "Year must be between 1900 and 2024");

            vehicle.Year = 2025;
            Assert.ThrowsException<Exception>(() => vehicle.ValidateYear(), "Year must be between 1900 and 2024");
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            var vehicle = new Vehicle { Price = 1000 };
            vehicle.ValidatePrice(); // Should not throw an exception

            vehicle.Price = -1;
            Assert.ThrowsException<Exception>(() => vehicle.ValidatePrice(), "Price must be greater than 0");
        }

        [TestMethod()]
        public void ValidateTest()
        {
            var vehicle = new Vehicle
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                Price = 20000
            };
            vehicle.Validate(); // Should not throw an exception

            vehicle.Brand = "T";
            Assert.ThrowsException<Exception>(() => vehicle.Validate(), "Brand must be at least 2 characters long");

            vehicle.Brand = "Toyota";
            vehicle.Model = "C";
            Assert.ThrowsException<Exception>(() => vehicle.Validate(), "Model must be at least 2 characters long");

            vehicle.Model = "Corolla";
            vehicle.Year = 1899;
            Assert.ThrowsException<Exception>(() => vehicle.Validate(), "Year must be between 1900 and 2024");

            vehicle.Year = 2020;
            vehicle.Price = -1;
            Assert.ThrowsException<Exception>(() => vehicle.Validate(), "Price must be greater than 0");
        }
    }
}