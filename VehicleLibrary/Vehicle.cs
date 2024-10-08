using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VehicleLibrary
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Price: {Price}";
        }
        public void ValidateBrand()
        {
            if (Brand == null || Brand.Length < 2)
            {
                throw new Exception("Brand must be at least 2 characters long");
            }
        }
        public void ValidateModel()
        {
            if (Model == null || Model.Length < 2)
            {
                throw new Exception("Model must be at least 2 characters long");
            }
        }
        public void ValidateYear()
        {
            if (Year < 1900 || Year > 2022)
            {
                throw new Exception("Year must be between 1900 and 2024");
            }
        }
        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new Exception("Price must be greater than 0");
            }
        }

        public void Validate()
        {
            ValidateBrand();
            ValidateModel();
            ValidateYear();
            ValidatePrice();
        }
    }
}
