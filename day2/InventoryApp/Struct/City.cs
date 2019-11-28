using System;

namespace InventoryApp.Struct
{
    public struct City
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public City(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

}