using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Person
    {
        public string FullName { get; set; }
        public int MyProperty { get; private set; } // private set
        public int TestRead { get; } = 12; // readonly property

        private string _age;

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }


        //private string _fullName;

        //public string FullName
        //{
        //    get { return _fullName; }
        //    set { _fullName = value; }
        //}

        //public void SetFullName(string fullName)
        //{
        //    FullName = fullName;
        //}
        //public  string  GetFullName()
        //{
        //    return FullName;
        //}


        public void Print()
        {
            Console.WriteLine($"Name = {_fullName}");
        }
    }
}
