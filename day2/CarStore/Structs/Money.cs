using System;
using CarStore.Enums;

namespace CarStore.Structs
{
    struct Money
    {
        public decimal Value { get; private set; }
        public Currencies Currency { get; private set; }

        public Money(decimal value, Currencies currency)
        {
            this.Value = value;
            this.Currency = currency;
        }
    }
}
