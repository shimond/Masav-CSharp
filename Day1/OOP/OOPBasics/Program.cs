using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// Program.cs
// .NET Framework 4.7.2 Example
// Demonstrates basic Object-Oriented Programming (OOP) concepts in C#
// Including: class definition, object instantiation, inheritance, properties, methods, and encapsulation
//
// This file is intended for educational purposes and targets .NET Framework 4.7.2 (see OOPBasics.csproj)

using System;

namespace OOPBasics
{
    // The main entry point for the application
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example: Creating an instance of a derived class (TimelifeProduct)
            var p2 = new TimelifeProduct()
            {
                Id = 2,
                Name = "Antivirus Software",
                Price = 49.99m,
                ExpirationDate = DateTime.Now.AddDays(360)
            };
            // Calls overridden PrintInfo() method (demonstrates polymorphism)
            p2.PrintInfo();

            // Example: Creating an array of base class (Product) objects
            Product[] products =
            {
                new Product(){ Id = 1, Name = "Laptop", Price = 999.99m },
                // You can add more Product or TimelifeProduct objects here
            };

            // Iterate through products and print info (demonstrates method call and polymorphism)
            foreach (var product in products)
            {
                PrintInfo(product);
            }

            // Uncomment below to see basic file operations (System.IO)
            //FileStream fs = new FileStream("1.txt", FileMode.Create);
            //BinaryWriter writer = new BinaryWriter(fs);
            //writer.Write(true);
            //StreamWriter sw = new StreamWriter(fs);
            //sw.Write(8);
        }

        // Demonstrates passing a base class reference (Product) and calling a virtual method
        static void PrintInfo(Product p)
        {
            p.PrintInfo();
        }
    }
}
