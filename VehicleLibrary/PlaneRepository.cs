using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    internal class PlaneRepository : IVehicleRepository<Plane>
    {
        private int nextId = 1;
        private List<Plane> planes = new List<Plane>();

        public void AddVehicle(Plane plane)
        {
            plane.Id = nextId++;
            plane.Validate();
            plane.ValidatePlane();
            planes.Add(plane);
        }

        public List<Plane> GetVehicles(int? minPrice = null, string? brand = null)
        {
            List<Plane> result = new List<Plane>(planes);
            if (minPrice != null)
            {
                result = result.FindAll(p => p.Price >= minPrice).ToList();
            }
            if (brand != null)
            {
                result = result.FindAll(p => p.Brand == brand).ToList();
            }
            return result;
        }

        public Plane? Get(int id)
        {
            return planes.FirstOrDefault(p => p.Id == id);
        }

        public Plane? Delete(int id)
        {
            Plane? plane = Get(id);
            if (plane == null)
            {
                return null;
            }
            planes.Remove(plane);
            return plane;
        }

        public Plane? Update(int id, Plane data)
        {
            data.Validate();
            data.ValidatePlane();
            Plane? existingPlane = Get(id);
            if (existingPlane == null)
            {
                return null;
            }
            existingPlane.Brand = data.Brand;
            existingPlane.Model = data.Model;
            existingPlane.Year = data.Year;
            existingPlane.Price = data.Price;
            existingPlane.WingType = data.WingType;
            existingPlane.EngineType = data.EngineType;
            return existingPlane;
        }
    }
}