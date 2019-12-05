using System;
using InventoryApp.Struct;
using InventoryApp.Interfaces;

namespace InventoryApp.Lib
{
    public class Room : IPrintable, IComparable<Room>
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

        int IComparable<Room>.CompareTo(Room other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Room other)
        {
            int adultsComp = this.Adults.CompareTo(other.Adults);
            int childrenComp = this.Children.CompareTo(other.Children);
            int rateComp = this.Rate.Amount.CompareTo(other.Rate.Amount);

            if (adultsComp == 0)
            {
                if(childrenComp == 0)
                {
                    if (rateComp == 0)
                    {
                        return 0;
                    }

                    if (childrenComp > 0)
                    {
                        return -1;
                    }
                }
            }

            if (adultsComp > 0)
            {
                return -1;
            }

            return 1;
        }
    }

}

