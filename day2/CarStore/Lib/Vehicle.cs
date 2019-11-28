using System;
using CarStore.Interface;
using CarStore.Enums;
using CarStore.Structs;

namespace CarStore.Lib
{
    class Vehicle : IVehicle
    {
        public CarManufactures Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Money Price { get; set; }

        public Vehicle(CarManufactures make)
        {
            this.Make = make;
        }

        public Vehicle(string model, int year)
        {
            this.Model = model;
            this.Year = year;
        }

        public override string ToString()
        {
            return $"Vehicle {this.Make} {this.Model} {this.Year}";
        }
    }
}
