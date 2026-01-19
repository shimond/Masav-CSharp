using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Select();
            //Update();
            //Delete();
            UseSp();
        }

        private static void UseSp()
        {
            MasavEntities masav = new MasavEntities();
            var results = masav.SelectPriceAndName().ToList();
            foreach (var item in results)
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }
        }

        private static void Delete()
        {
            MasavEntities masav = new MasavEntities();
            var p = masav.Products.FirstOrDefault(x => x.Id == 3);
            masav.Products.Remove(p);
            masav.SaveChanges();

        }

        private static void Update()
        {
            MasavEntities masav = new MasavEntities();
            var user = masav.Users.FirstOrDefault();
            user.Name = "WOW!";
            Product product = new Product();
            product.Name = "NEW NAME";
            product.Description = "WOW WOW";
            product.Price = 18;
            product.IsInStock = true;
            user.Products.Add(product);

            masav.SaveChanges();
        }

        private static void Select()
        {
            MasavEntities masav = new MasavEntities();
            var usersQuery = masav.Users
                .Where(x => x.Name.Contains("a"))
                .OrderBy(x => x.Name).ThenBy(x => x.Id);

            var users = usersQuery.ToList();

            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
