using System;
using InventoryApp.Enums;

namespace InventoryApp.Lib
{
    public class Money : IComparable<Money>
    {
        public decimal Value { get; private set; }

        public Currencies Currency { get; private set; }

        public Money(decimal value, Currencies currency)
        {
            this.Value = value;
            this.Currency = currency;
        }
        
        public static bool operator >(Money a, Money b)
        {
            // check for currency
            return a.Value > b.Value;
        }
        public static bool operator <(Money a, Money b)
        {
            // check for currency
            return a.Value < b.Value;
        }

        public override string ToString()
        {
            return $"{this.Value} {this.Currency}";
        }

        public int CompareTo(Money other)
        {
            if (this.Currency != other.Currency)
            {
                throw new ArgumentException("Cannot compare different currencies.");
            }

            if (this.Value == other.Value)
            {
                return 0;
            }

            return this.Value > other.Value ? 1 : -1;
        }
    }

}