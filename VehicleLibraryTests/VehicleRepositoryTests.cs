using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary.Tests
{
    [TestClass()]
    public class VehicleRepositoryTests
    {
        [TestMethod()]
        public void AddVehicleTest()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };

            // Act
            repository.AddVehicle(vehicle);

            // Assert
            Assert.AreEqual(1, vehicle.Id);
            CollectionAssert.Contains(repository.GetVehicles(), vehicle);
        }

        [TestMethod()]
        public void GetVehiclesTest()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle1 = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Brand = "Honda",
                Model = "Accord",
                Year = 2021,
                Price = 23000
            };
            repository.AddVehicle(vehicle1);
            repository.AddVehicle(vehicle2);

            // Act
            List<Vehicle> vehicles = repository.GetVehicles();

            // Assert
            Assert.AreEqual(2, vehicles.Count);
            CollectionAssert.Contains(vehicles, vehicle1);
            CollectionAssert.Contains(vehicles, vehicle2);
        }

        [TestMethod()]
        public void GetVehiclesTest_WithMinPrice()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle1 = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Brand = "Honda",
                Model = "Accord",
                Year = 2021,
                Price = 23000
            };
            repository.AddVehicle(vehicle1);
            repository.AddVehicle(vehicle2);

            // Act
            List<Vehicle> vehicles = repository.GetVehicles(minPrice: 24000);

            // Assert
            Assert.AreEqual(1, vehicles.Count);
            CollectionAssert.Contains(vehicles, vehicle1);
        }

        [TestMethod()]
        public void GetVehiclesTest_WithBrand()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle1 = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Brand = "Honda",
                Model = "Accord",
                Year = 2021,
                Price = 23000
            };
            repository.AddVehicle(vehicle1);
            repository.AddVehicle(vehicle2);

            // Act
            List<Vehicle> vehicles = repository.GetVehicles(brand: "Toyota");

            // Assert
            Assert.AreEqual(1, vehicles.Count);
            CollectionAssert.Contains(vehicles, vehicle1);
        }

        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };
            repository.AddVehicle(vehicle);

            // Act
            Vehicle result = repository.Get(vehicle.Id);

            // Assert
            Assert.AreEqual(vehicle, result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };
            repository.AddVehicle(vehicle);

            // Act
            Vehicle deletedVehicle = repository.Delete(vehicle.Id);

            // Assert
            Assert.AreEqual(vehicle, deletedVehicle);
            CollectionAssert.DoesNotContain(repository.GetVehicles(), vehicle);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            VehicleRepository repository = new VehicleRepository();
            Vehicle vehicle = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Price = 25000
            };
            repository.AddVehicle(vehicle);

            Vehicle updatedVehicle = new Vehicle()
            {
                Id = vehicle.Id, // Ensure the ID is set to the existing vehicle's ID
                Brand = "Honda",
                Model = "Accord",
                Year = 2021,
                Price = 23000
            };

            // Act
            Vehicle result = repository.Update(vehicle.Id, updatedVehicle);

            // Assert
            Assert.AreEqual(vehicle.Id, result.Id); // Ensure the ID remains the same
            Assert.AreEqual(updatedVehicle.Brand, result.Brand);
            Assert.AreEqual(updatedVehicle.Model, result.Model);
            Assert.AreEqual(updatedVehicle.Year, result.Year);
            Assert.AreEqual(updatedVehicle.Price, result.Price);
        }
    }
}