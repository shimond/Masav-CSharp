using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual void PrintInfo() {
            Console.WriteLine(  "Im Product");
        }
    }


    public class TimelifeProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine("Im TimelifeProduct");
        }
        public TimelifeProduct() : base()
        {
        }
    }

    public interface IDrawable
    {
        void Draw();
    }

    public abstract class Shape
    {
        public int Id { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }


    public  interface ILogger
    {
        void Log(string message);
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class DCircle : Circle, IDrawable
    {
        public void Draw()
        {
            Console.WriteLine("DRAW IT");
        }
    }


    class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2* (Height + Width);
        }

    }















}
