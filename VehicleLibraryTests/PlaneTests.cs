using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleLibrary;
using System;

namespace VehicleLibrary.Tests
{
    [TestClass()]
    public class PlaneTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var plane = new Plane
            {
                Id = 1,
                Brand = "Boeing",
                Model = "747",
                Year = 2020,
                Price = 150000000,
                MaxAltitude = 35000,
                EngineType = "jet",
                WingType = "monoplane"
            };

            // Act
            var result = plane.ToString();

            // Assert
            var expected = "Id: 1, Brand: Boeing, Model: 747, Year: 2020, Price: 150000000, Max Altitude: 35000, Engine Type: jet, Wing Type: monoplane";
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Max Altitude must not be a negative value")]
        public void ValidateMaxAltitudeTest()
        {
            // Arrange
            var plane = new Plane { MaxAltitude = -100 };

            // Act
            plane.ValidateMaxAltitude();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "The Plane must have a valid engine type")]
        public void ValidateEngineTypeTest()
        {
            // Arrange
            var plane = new Plane { EngineType = "invalid" };

            // Act
            plane.ValidateEngineType();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "The Plane must have a valid wing type")]
        public void ValidateWingTypeTest()
        {
            // Arrange
            var plane = new Plane { WingType = "invalid" };

            // Act
            plane.ValidateWingType();
        }

        [TestMethod()]
        public void ValidatePlaneTest()
        {
            // Arrange
            var plane = new Plane
            {
                Id = 1,
                Brand = "Boeing",
                Model = "747",
                Year = 2020,
                Price = 150000000,
                MaxAltitude = 35000,
                EngineType = "jet",
                WingType = "monoplane"
            };

            // Act & Assert
            plane.ValidatePlane();
        }
    }
}