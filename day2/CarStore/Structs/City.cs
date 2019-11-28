using System;

namespace CarStore.Structs
{   
    struct City
    {
        public string Name { get; private set; }

        public City(string name)
        {
            this.Name = name;
        }
    }
}
