// Person.cs
// .NET Framework 4.7.2 Example
// Demonstrates a simple Person class with properties, encapsulation, and a method
// This file is intended for educational purposes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    // The Person class represents a person with a name and age
    public class Person
    {
        // Auto-implemented property for full name (public get/set)
        public string FullName { get; set; }

        // Property with private setter (can only be set inside this class)
        public int MyProperty { get; private set; }

        // Read-only property (set only at initialization)
        public int TestRead { get; } = 12;

        // Private field for age (encapsulation)
        private string _age;

        // Property for age with explicit getter and setter
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        // Example of classic property implementation (commented out)
        //private string _fullName;
        //public string FullName
        //{
        //    get { return _fullName; }
        //    set { _fullName = value; }
        //}

        // Example of classic getter/setter methods (commented out)
        //public void SetFullName(string fullName)
        //{
        //    FullName = fullName;
        //}
        //public string GetFullName()
        //{
        //    return FullName;
        //}

        // Prints the person's name to the console
        public void Print()
        {
            // Note: _fullName is not used in this implementation; use FullName instead
            Console.WriteLine($"Name = {FullName}");
        }
    }
}
