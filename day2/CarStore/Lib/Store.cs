using System;
using System.Collections.Generic;
using CarStore.Interface;
using CarStore.Structs;
using CarStore.Enums;

namespace CarStore.Lib
{
    class Store : IStore
    {
        public CarManufactures Name { get; private set; }
        public City City { get; private set; }

        private List<IVehicle> vehicles = new List<IVehicle>();

        public List<Order> orders = new List<Order>();

        public Store(CarManufactures name)
        {
            this.Name = name;
        }

        public void AddVehicle(IVehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            if ( ! this.vehicles.Contains(vehicle))
            {
                throw new ArgumentException($"Vehicle {vehicle} does not exists in the store.");
            }

            this.vehicles.Remove(vehicle);
        }

        public void CreateOrder(Customer c, Vehicle v, DateTime delivery)
        {
            Order order = new Order(c, v, delivery);
            this.orders.Add(order);
            Logger.Log.Info($"New order: \n {order} created in store {this}");
        }

        public void RemoveOrder(Order order)
        {
            if (this.orders.Contains(order))
            {
                this.orders.Remove(order);
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
