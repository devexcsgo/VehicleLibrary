using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class Plane : Vehicle
    {
        public int MaxAltitude { get; set; }
        public string? EngineType { get; set; }
        public string? WingType { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Price: {Price}, Max Altitude: {MaxAltitude}, Engine Type: {EngineType}, Wing Type: {WingType}";
        }

        public void ValidateMaxAltitude()
        {
            if (MaxAltitude <= 0)
            {
                throw new Exception("Max Altitude must not be a negative value");
            }
        }

        public void ValidateEngineType()
        {
            if (EngineType == null || !IsValidEngineType(EngineType))
            {
                throw new Exception("The Plane must have a valid engine type");
            }
        }

        private bool IsValidEngineType(string engineType)
        {
            string[] validEngineTypes = { "jet", "propeller", "electric" };

            return validEngineTypes.Contains(engineType.ToLower());
        }

        public void ValidateWingType()
        {
            if (WingType == null || !IsValidWingType(WingType))
            {
                throw new Exception("The Plane must have a valid wing type");
            }
        }

        private bool IsValidWingType(string wingType)
        {
            string[] validWingTypes = { "monoplane", "biplane", "triwing" };

            return validWingTypes.Contains(wingType.ToLower());
        }

        public void ValidatePlane()
        {
            ValidateBrand();
            ValidateModel();
            ValidateYear();
            ValidatePrice();
            ValidateMaxAltitude();
            ValidateEngineType();
            ValidateWingType();
        }
    }
}