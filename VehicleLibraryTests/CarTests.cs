using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleLibrary;
using System;

namespace VehicleLibrary.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var car = new Car
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                Price = 20000,
                Milage = 15000,
                Color = "Red",
                FuelType = "Benzin",
                Transmission = "Automatic"
            };
            var expected = "Id: 1, Brand: Toyota, Model: Corolla, Year: 2020, Price: 20000, Milage: 15000, Color: Red, Fuel Type: Benzin Transmission: Automatic";
            Assert.AreEqual(expected, car.ToString());
        }

        [TestMethod()]
        public void ValidateMilageTest()
        {
            var car = new Car { Milage = 15000 };
            car.ValidateMilage(); // Should not throw an exception

            car.Milage = -1;
            Assert.ThrowsException<Exception>(() => car.ValidateMilage(), "Milage must not be a negative value");
        }

        [TestMethod()]
        public void ValidateColorTest()
        {
            var car = new Car { Color = "Red" };
            car.ValidateColor(); // Should not throw an exception

            car.Color = "R";
            Assert.ThrowsException<Exception>(() => car.ValidateColor(), "The Car must have a valid color");

            car.Color = "InvalidColor";
            Assert.ThrowsException<Exception>(() => car.ValidateColor(), "The Car must have a valid color");

            car.Color = null;
            Assert.ThrowsException<Exception>(() => car.ValidateColor(), "The Car must have a valid color");
        }

        [TestMethod()]
        public void ValidateFuelTypeTest()
        {
            var car = new Car { FuelType = "Benzin" };
            car.ValidateFuelType(); // Should not throw an exception

            car.FuelType = "InvalidFuelType";
            Assert.ThrowsException<Exception>(() => car.ValidateFuelType(), "The Car must have a valid fuel type");

            car.FuelType = null;
            Assert.ThrowsException<Exception>(() => car.ValidateFuelType(), "The Car must have a valid fuel type");
        }

        [TestMethod()]
        public void ValidateTransmissionTest()
        {
            var car = new Car { Transmission = "Manual" };
            car.ValidateTransmission(); // Should not throw an exception

            car.Transmission = "InvalidTransmission";
            Assert.ThrowsException<Exception>(() => car.ValidateTransmission(), "The Car must have a valid transmission type");

            car.Transmission = null;
            Assert.ThrowsException<Exception>(() => car.ValidateTransmission(), "The Car must have a valid transmission type");
        }

        [TestMethod()]
        public void ValidateCarTest()
        {
            var car = new Car
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                Price = 20000,
                Milage = 15000,
                Color = "Red",
                FuelType = "Benzin",
                Transmission = "Automatic"
            };
            car.ValidateCar(); // Should not throw an exception

            car.Milage = -1;
            Assert.ThrowsException<Exception>(() => car.ValidateCar(), "Milage must not be a negative value");

            car.Color = "R";
            Assert.ThrowsException<Exception>(() => car.ValidateCar(), "The Car must have a valid color");

            car.FuelType = "InvalidFuelType";
            Assert.ThrowsException<Exception>(() => car.ValidateCar(), "The Car must have a valid fuel type");

            car.Transmission = "InvalidTransmission";
            Assert.ThrowsException<Exception>(() => car.ValidateCar(), "The Car must have a valid transmission type");
        }
    }
}