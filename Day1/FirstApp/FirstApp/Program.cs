// Program.cs
// .NET Framework 4.7.2 Example
// Demonstrates basic C# programming concepts and OOP principles
// Including: method overloading, reference vs value types, encapsulation, and control flow
//
// This file is intended for educational purposes and targets .NET Framework 4.7.2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Logic;
using System.Diagnostics;

namespace FirstApp
{
    // Access modifiers:
    // public - accessible from any other code
    // private - accessible only within the same class or struct
    // internal - accessible only within files in the same assembly
    // protected - accessible within its class and by derived class instances

    // Main class for the application
    internal class ProgramOfMyTest
    {
        // Example: Validates an Israeli ID (Teudat Zehut) number
        static bool ValidateIsraeliTz(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            int sum = 1;
            for (int i = 0; i < 9; i++)
            {
                int d = s[i] - '0';
                int product = (i % 2 == 0) ? d : d * 2;
                if (product > 9)
                {
                    product -= 9;
                }
                sum += product;
            }
            return sum % 10 == 0;
        }

        // Method overloading: same method name, different parameter types
        static void Test(int x)
        {
            Console.WriteLine(x);
            x = 101; // Value type: changes here do not affect the caller
        }

        static void Test(string x)
        {
            Console.WriteLine(x);
            x = "Asdasd"; // Reference type: but string is immutable
        }

        // Returns true if string length > 5
        static bool IsOk(string str)
        {
            var namOfTheTest = "asd";
            return str.Length > 5;
        }

        // Demonstrates passing array by reference
        static void Test1(ref string[] arr)
        {
            arr = new string[] { "SHIMON", "MOSHE" };
        }

        // Demonstrates StringBuilder for efficient string manipulation
        static void TestA(string str)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            for (int i = 0; i < 1000000; i++)
            {
                stringBuilder.Append("A");
            }
        }

        // Main entry point
        static void Main(string[] args)
        {
            // Uncomment to test input and validation
            //var input = Console.ReadLine();
            //Console.WriteLine(10 / int.Parse(input));
            //var isOk = ValidateIsraeliTz(input);
            //Console.WriteLine(isOk);

            // Demonstrates object creation and property usage
            Person p = new Person();
            p.FullName = "Shimon"; // set property
            p.Print(); // call method
            Console.WriteLine(p.FullName); // get property
        }

        // Demonstrates if/else and switch statements
        private static void Ifs()
        {
            int x = 0;

            if (x > 10)
            {
                Console.WriteLine("YES");
            }
            else if (x < 5)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("MAYBE");
            }

            bool isOk = 10 > 5;
            var res = 10 > 5 ? "YES" : "NO";

            switch (x)
            {
                case 10:
                    Console.WriteLine("10");
                    break;
                case 20:
                    Console.WriteLine("10");
                    break;
                default:
                    Console.WriteLine("OTHER");
                    break;
            }
        }

        // Demonstrates basic data types
        private static void basics()
        {
            byte b = 154;
            short s = 0;
            int i = 0;
            long l = 0;

            uint u = 200;

            float f = 0.7f;
            double d = 0.7;
            decimal dec = 0.7m;

            string str = "Hello, World!";
            char c = 'A';

            bool bo = true;
            DateTime dateTime = DateTime.Now;
        }
    }
}
           