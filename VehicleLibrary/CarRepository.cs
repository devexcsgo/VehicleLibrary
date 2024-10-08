using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class CarRepository : IVehicleRepository<Car>
    {
        private int nextId = 1;
        private List<Car> cars = new List<Car>();

        public void AddVehicle(Car car)
        {
            car.Id = nextId++;
            car.Validate();
            car.ValidateCar();
            cars.Add(car);
        }

        public List<Car> GetVehicles(int? minPrice = null, string? brand = null)
        {
            List<Car> result = new List<Car>(cars);
            if (minPrice != null)
            {
                result = result.FindAll(c => c.Price >= minPrice).ToList();
            }
            if (brand != null)
            {
                result = result.FindAll(c => c.Brand == brand).ToList();
            }
            return result;
        }

        public Car? Get(int id)
        {
            return cars.FirstOrDefault(c => c.Id == id);
        }

        public Car? Delete(int id)
        {
            Car? car = Get(id);
            if (car == null)
            {
                return null;
            }
            cars.Remove(car);
            return car;
        }

        public Car? Update(int id, Car data)
        {
            data.Validate();
            data.ValidateCar();
            Car? existingCar = Get(id);
            if (existingCar == null)
            {
                return null;
            }
            existingCar.Brand = data.Brand;
            existingCar.Model = data.Model;
            existingCar.Year = data.Year;
            existingCar.Price = data.Price;
            existingCar.Milage = data.Milage;
            existingCar.Color = data.Color;
            existingCar.FuelType = data.FuelType;
            existingCar.Transmission = data.Transmission;
            return existingCar;
        }
    }
}