using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);
        Vehicle? Update(int id, Vehicle data);
        Vehicle? Delete(int id);
        Vehicle Get(int id);
        List<Vehicle> GetVehicles(int? minPrice = null, string? brand = null);
    }
}
