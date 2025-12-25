using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FileStream fs = new FileStream("1.txt", FileMode.Create);
            //BinaryWriter writer = new BinaryWriter(fs);
            //writer.Write(true);

            //StreamWriter sw = new StreamWriter(fs);
            //sw.Write(8);

            var p2 = new TimelifeProduct()
            {
                Id = 2,
                Name = "Antivirus Software",
                Price = 49.99m,
                ExpirationDate = DateTime.Now.AddDays(360)
            };
            p2.PrintInfo();
            Product[] products =
            {
                new Product(){ Id = 1, Name = "Laptop", Price = 999.99m },

            };

            foreach (var product in products)
            {
                PrintInfo(product);
            }

        }
        static void PrintInfo(Product p)
        {
            p.PrintInfo();
        }
    }
}
