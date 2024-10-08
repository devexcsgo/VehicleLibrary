using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class VehicleRepository : IVehicleRepository
    {
        private int nextId = 1;
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicle.Id = nextId++;
            vehicle.Validate();
            vehicles.Add(vehicle);
        }

        public List<Vehicle> GetVehicles(int? minPrice = null, string? brand = null)
        {
            List<Vehicle> result = new List<Vehicle>(vehicles);
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

        public Vehicle? Get(int id)
        {
            return vehicles.FirstOrDefault(t => t.Id == id);
        }
        public Vehicle? Delete(int id)
        {
            Vehicle? vehicle = Get(id);
            if (vehicle == null)
            {
                return null;
            }
            vehicles.Remove(vehicle);
            return vehicle;
        }

        public Vehicle? Update(int id, Vehicle data)
        {
            data.Validate();
            Vehicle? exsistingVehicle = Get(id);
            if (exsistingVehicle == null)
            {
                return null;
            }
            exsistingVehicle.Brand = data.Brand;
            exsistingVehicle.Model = data.Model;
            exsistingVehicle.Year = data.Year;
            exsistingVehicle.Price = data.Price;
            return exsistingVehicle;

        }
    }
}
