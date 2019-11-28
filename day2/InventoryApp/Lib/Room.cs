using System;
using InventoryApp.Struct;
using InventoryApp.Interfaces;

namespace InventoryApp.Lib
{
    public class Room : IPrintable
    {
        int Id { get; set; }
        public string Name { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        Rate Rate { get; set; }

        public Room()
        {}

        public Room(int id, string name, int adults, int children, Rate rate)
        {
            this.Id = id;
            this.Name = name;
            this.Adults = adults;
            this.Children = children;
            this.Rate = rate;
        }

        public Money GetPriceForDays(int numberOfDays)
        {
            return new Money(Rate.Amount.Value * numberOfDays, Rate.Amount.Currency);
        }
        public override string ToString()
        {
            return $"Room: {this.Name}, Adults: {this.Adults}, Children: {this.Children}, Rate: {this.Rate}";
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());

        }
    }

}

