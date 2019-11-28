using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Lib
{
    class Order
    {
        public Customer Customer { get; private set; }

        public Vehicle Vehicle { get; private set; }

        public DateTime Delivery { get; private set; }

        public Order(Customer c, Vehicle v, DateTime d)
        {
            this.Customer = c;
            this.Vehicle = v;
            this.Delivery = d;
        }

        public override string ToString()
        {
            return $"Made by {this.Customer} for {this.Vehicle} with delivery on {this.Delivery}";
        }
    }
}
