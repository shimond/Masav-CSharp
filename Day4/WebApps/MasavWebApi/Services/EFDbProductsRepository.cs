using MasavWebApi.Contracts;
using MasavWebApi.Data;
using MasavWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MasavWebApi.Services
{
    public class EFDbProductsRepository : IProductRepository
    {

        public EFDbProductsRepository()
        {
            
        }
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
            return items;
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