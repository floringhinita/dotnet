using System;
using CarStore.Lib;
using CarStore.Structs;
using CarStore.Logger;
using CarStore.Enums;

namespace CarStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Andy", "Barosanul");
           
            Store fordStore = new Store(CarManufactures.Ford);

            Vehicle v = new Vehicle(CarManufactures.Ford) { 
                Model = "Focus",
                Year = 2018,
                Price = new Money(15000, Currencies.EUR)
            };
           
            fordStore.CreateOrder(customer, v, DateTime.Today.AddDays(15));

            Store skodaStore = new Store(CarManufactures.Skoda);

            Vehicle vs = new Vehicle(CarManufactures.Skoda)
            {
                Model = "Octavia",
                Year = 2018,
                Price = new Money(14000, Currencies.EUR)
            };

            skodaStore.CreateOrder(customer, vs, DateTime.Today.AddDays(14));


        }
    }
}
