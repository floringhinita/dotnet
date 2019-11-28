using System;
using InventoryApp.Struct;

namespace InventoryApp.Lib
{
    public class Rate
    {
        public Money Amount { get; set; }

        public Rate(Money amount)
        {
            this.Amount = amount;
        }

        public override string ToString()
        {
            return this.Amount.ToString();
        }
    }

}