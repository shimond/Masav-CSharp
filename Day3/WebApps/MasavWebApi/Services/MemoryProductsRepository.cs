using MasavWebApi.Contracts;
using MasavWebApi.Data;
using MasavWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Management;

namespace MasavWebApi.Services
{
    public class MemoryProductsRepository : IProductRepository
    {
        public static List<Product> products = new List<Product>();
        public Task<Product> AddProduct(Product product)
        {
            var lastId = products.Count == 0 ? 0 : products.Max(p => p.Id);
            product.Id = lastId + 1;
            products.Add(product);
            return Task.FromResult(product);
        }

        public Task DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            } 
            return Task.CompletedTask;
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(products);
        }

        public async Task<Product> GetProductById(int id)
        {
            await Task.Delay(50); 
            return products.FirstOrDefault(p => p.Id == id);

        }

        public async Task<Product> GetProductByName(string name)
        {
            await Task.Delay(50);
            return products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateProduct(Product product)
        {
            var productToUpdate = products.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.IsInStock = product.IsInStock;
            }
            return Task.CompletedTask;
        }
    }
}