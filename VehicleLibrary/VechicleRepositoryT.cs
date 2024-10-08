using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class VehicleRepository<T> : IVehicleRepository<T> where T : Vehicle
    {
        private int nextId = 1;
        private List<T> vehicles = new List<T>();

        public void AddVehicle(T vehicle)
        {
            vehicle.Id = nextId++;
            vehicle.Validate();
            vehicles.Add(vehicle);
        }

        public List<T> GetVehicles(int? minPrice = null, string? brand = null)
        {
            List<T> result = new List<T>(vehicles);
            if (minPrice != null)
            {
                result = result.FindAll(v => v.Price >= minPrice).ToList();
            }
            if (brand != null)
            {
                result = result.FindAll(v => v.Brand == brand).ToList();
            }
            return result;
        }

        public T? Get(int id)
        {
            return vehicles.FirstOrDefault(t => t.Id == id);
        }
        public T? Delete(int id)
        {
            T? vehicle = Get(id);
            if (vehicle == null)
            {
                return null;
            }
            vehicles.Remove(vehicle);
            return vehicle;
        }

        public T? Update(int id, T data)
        {
            data.Validate();
            T? existingVehicle = Get(id);
            if (existingVehicle == null)
            {
                return null;
            }
            existingVehicle.Brand = data.Brand;
            existingVehicle.Model = data.Model;
            existingVehicle.Year = data.Year;
            existingVehicle.Price = data.Price;
            return existingVehicle;

        }
    }
}
