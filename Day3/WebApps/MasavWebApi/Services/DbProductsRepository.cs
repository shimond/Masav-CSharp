using MasavWebApi.Contracts;
using MasavWebApi.Data;
using MasavWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MasavWebApi.Services
{
    public class DbProductsRepository : IProductRepository
    {

        public async Task<Product> AddProduct(Product product)
        {
            MasavEntities masavEntities = new MasavEntities();
            masavEntities.Products.Add(product);
            await masavEntities.SaveChangesAsync();
            return product;
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            MasavEntities entities = new MasavEntities();
            var items = await entities.Products.ToListAsync();
            
            var r = await entities.Users
                .Include(x => x.Products)
                //.AsSplitQuery()

                .ToListAsync();
            
            
            return items;

            //var query = "SELECT Id, Name, Description, Price, IsInStock FROM Products";
            //SqlConnection connection = new SqlConnection("YourConnectionStringHere");
            //await connection.OpenAsync();
            //SqlCommand command = new SqlCommand(query, connection);
            //SqlDataReader reader = await command.ExecuteReaderAsync();
            //List<Product> products = new List<Product>();
            //while (await reader.ReadAsync())
            //{
            //    products.Add(new Product()
            //    {
            //        Description = reader["Description"].ToString(),
            //        Id = Convert.ToInt32(reader["Id"]),
            //        IsInStock = Convert.ToBoolean(reader["IsInStock"]),
            //        Name = reader["Name"].ToString(),
            //        Price = Convert.ToDouble(reader["Price"])
            //    });
            //}
            //return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            MasavEntities masavEntities = new MasavEntities();
            var product = await masavEntities.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product> GetProductByName(string name)
        {
            MasavEntities masavEntities = new MasavEntities();
            var product = await masavEntities.Products.FirstOrDefaultAsync(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            MasavEntities entities = new MasavEntities();
            entities.Entry(product).State = EntityState.Modified;
            await entities.SaveChangesAsync();
        }
    }
}