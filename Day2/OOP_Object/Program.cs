using System;
using System.Threading;

namespace OOP_Object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("John Doe");
            ////person.FullName = "John Doe";
            //person.PrintInfo();

            ////Person anotherPerson = new Person("Jane", "Smith");
            //Person anotherPerson = new Person(firstName:"Jane", lastName: "Smith");
            ////anotherPerson.FullName = "Jane Smith";
            //anotherPerson.PrintInfo();

            object p = new Person()
            {
                //Id = 1,
                FullName = "Moshe Cohen"
            };



            if (p is Person)
            {
                ((Person)p).PrintInfo();
            }

            var p1 = p as Person;
            if(p1 != null)
            {
                p1.PrintInfo();
            }









        }
        static void Test(Person p)
        {
            p.PrintInfo();
        }

        static void Test(object p)
        {
            Console.WriteLine(p.ToString());
        }

        static void Test(Worker p)
        {
            p.PrintInfo();
        }

    }

    public class Person : Object
    {
        protected int ProtectedField { get; set; }
        private string _firstName;
        private string _lastName;


        //public required int Id { get; set; }
        public string FullName
        {
            get
            {

                return _firstName + " " + _lastName;
            }
            set
            {
                var values = value.Split(' ');
                this._firstName = values[0];
                this._lastName = values[1];
            }
        }

        public int FullNameLength
        {
            get
            {
                return FullName.Length;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Full Name: " + FullName);
        }

        public Person() : this("NO_FIRST_NAME", "NO_LAST_NAME")
        {

        }


        public Person(string fullName)
        {
            this.FullName = fullName;
        }

        public Person(string firstName, string lastName) : this(firstName + " " + lastName)
        {
            //this._firstName = firstName;
            //this._lastName = lastName;
        }

        //public Person(string firstName, string lastName)
        //{
        //    this._firstName = firstName;
        //    this._lastName = lastName;
        //}


    }


    public class Worker : Person
    {
        public string CompanyName { get; set; }
        public sealed override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Company Name: " + CompanyName);
        }
    }

    //v1 - bad design
    //public class Person
    //{
    //    public string FullName;

    //    public void PrintInfo()
    //    {
    //        Console.WriteLine("Full Name: " + FullName);
    //    }
    //}


    //v2 - 
    //public class Person
    //{
    //    public string FirstName;
    //    public string LastName;

    //    public void PrintInfo()
    //    {
    //        Console.WriteLine("Full Name: " + FirstName + " " + LastName);
    //    }
    //}
}

