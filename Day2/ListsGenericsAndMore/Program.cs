using ListsGenericsAndMore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsGenericsAndMore
{

    public delegate bool Filter<T>(T person);

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person { Id=1, Name="John", Age=30 },
                new Person { Id=2, Name="Jane", Age=15 },
                new Person { Id=3, Name="Mike", Age=15 },
                new Person { Id=4, Name="Moshe", Age=15 },
                new Person { Id=5, Name="Noam", Age=30 },
                new Person { Id=6, Name="Naama", Age=5 },
                new Person { Id=7, Name="Amir", Age=55 },
            };
            int ageToCompare = 60;

            //var list = Filter(people, FilterByAge);
            //var list = people.Filter(p => p.Age > ageToCompare);
            //var items = list.Where(p => p.Age < 50);
            //var items1 = list.OrderBy(x => x.Name).ThenBy(x => x.Age);
            //var count = list.Count(x => x.Age > 50);
            //var groups = list.GroupBy(x => x.Age).Select(x => new { x.Key, items = x.ToArray() });
            //var any = list.Any(x => x.Age > 50);
            //var first = list.First(x => x.Age > 100);

            var items = people.Where(p => p.Age < 50).AsParallel().ToList();

            items.ToList();


            foreach (var item in items)
            {

            }


            List<Action> actions = new List<Action>();
            int max = int.Parse(Console.ReadLine());
            for (int i = 0; i < max; i++)
            {
                var x = i;
                actions.Add(() => Console.WriteLine(x));
            }

            foreach (var item in actions)
            {
                item();
            }

        }

        static bool FilterByAge(Person person)
        {
            return person.Age > 60;
        }


        static void PrintPeople(List<Person> list)
        {
            foreach (var person in list)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");
            }
        }




        static List<Person> GetListFilter2(List<Person> list)
        {
            var filter = new List<Person>();
            foreach (var person in list)
            {
                if (person.Name.Contains("N"))
                {
                    filter.Add(person);
                }
            }

            return filter;
        }


        static List<Person> GetListFilter(List<Person> list)
        {
            var filter = new List<Person>();
            foreach (var person in list)
            {
                if (person.Age > 60)
                {
                    filter.Add(person);
                }
            }
            string name = "shimon";
            return filter;
        }

    }
}


public static class Extensions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Filter<T> predicate)
    {
        foreach (var item in list)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static void Print(this string s)
    {
        Console.WriteLine(s);
    }
}



