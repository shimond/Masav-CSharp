using MasavWebApi.Data;
using MasavWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasavWebApi.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
