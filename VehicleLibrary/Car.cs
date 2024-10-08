using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    public class Car : Vehicle
    {
        public int Milage { get; set; }
        public string? Color { get; set; }
        public string? FuelType { get; set; }
        public string? Transmission { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Price: {Price}, Milage: {Milage}, Color: {Color}, Fuel Type: {FuelType} Transmission: {Transmission}";
        }

        public void ValidateMilage()
        {
            if (Milage <= 0)
            {
                throw new Exception("Milage must not be a negative value");
            }
        }

        public void ValidateColor()
        {
            if (Color == null || Color.Length < 2 || !IsValidColor(Color))
            {
                throw new Exception("The Car must have a valid color");
            }
        }

        private bool IsValidColor(string color)
        {
            string[] validColors = { "red", "blue", "green", "yellow" };

            return validColors.Contains(color.ToLower());
        }

        public void ValidateFuelType()
        {
            if (FuelType == null || !IsValidFuelType(FuelType))
            {
                throw new Exception("The Car must have a valid fuel type");
            }
        }

        private bool IsValidFuelType(string fuelType)
        {
            string[] validFuelTypes = { "benzin", "diesel", "el" };

            return validFuelTypes.Contains(fuelType.ToLower());
        }

        public void ValidateTransmission()
        {
            if (Transmission == null || !IsValidTransmission(Transmission))
            {
                throw new Exception("The Car must have a valid transmission type");
            }
        }

        private bool IsValidTransmission(string transmission)
        {
            string[] validTransmissions = { "manual", "automatic" };

            return validTransmissions.Contains(transmission.ToLower());
        }

        public void ValidateCar()
        {
            Validate();
            ValidateMilage();
            ValidateColor();
            ValidateFuelType();
            ValidateTransmission();
        }
    }
}