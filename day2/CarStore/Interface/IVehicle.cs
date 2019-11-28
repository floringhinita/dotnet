using System;
using CarStore.Structs;
using CarStore.Enums;
using CarStore.Lib;

namespace CarStore.Interface
{
    interface IVehicle
    {
        public CarManufactures Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Money Price { get; set; }
    }
}
