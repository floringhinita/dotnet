using System;
using CarStore.Interface;

namespace CarStore.Lib
{
    class Customer : IPerson
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Customer(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            Logger.Log.Info($"customer created {this.Name}");

        }

        public string Name
        {
            get {
                return this.FirstName + " " + this.LastName;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
