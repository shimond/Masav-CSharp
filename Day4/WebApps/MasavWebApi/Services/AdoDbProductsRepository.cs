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
    public class AdoDbProductsRepository: IProductRepository
    {
        private string _connectionString;

        public AdoDbProductsRepository()
        {
             _connectionString = ConfigurationManager.ConnectionStrings["MasavDb"].ConnectionString;
        }
        public async Task<Product> AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var insertQuery = "INSERT INTO Products (Name, Description, Price, IsInStock) VALUES (@Name, @Description, @Price, @IsInStock);SELECT SCOPE_IDENTITY();";
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@IsInStock", product.IsInStock);
                    //var dataReader = command.ExecuteReader();
                    //var valuefromDb = command.ExecuteScalar();
                    //var rowAffected = command.ExecuteNonQuery();
                    //if (rowAffected == 0)
                    //{
                    //    throw new Exception("Insert failed - conflict");
                    //}
                    var newId = command.ExecuteScalar();
                    product.Id = Convert.ToInt32(newId);
                }
                return product;
            }

        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var query = "SELECT Id, Name, Description, Price, IsInStock FROM Products";
            SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand(query, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Product> products = new List<Product>();
            while (await reader.ReadAsync())
            {
                products.Add(new Product()
                {
                    Description = reader["Description"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                    IsInStock = Convert.ToBoolean(reader["IsInStock"]),
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToDouble(reader["Price"])
                });
            }
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var query = "SELECT Id, Name, Description, Price, IsInStock FROM Products Where Id = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    //command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        Product product = new Product();
                        if (reader.Read())
                        {
                            product = new Product()
                            {
                                Description = reader["Description"].ToString(),
                                Id = Convert.ToInt32(reader["Id"]),
                                IsInStock = Convert.ToBoolean(reader["IsInStock"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDouble(reader["Price"])
                            };
                            return product;
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }

        }

        public async Task<Product> GetProductByName(string name)
        {
            var query = "SELECT Id, Name, Description, Price, IsInStock FROM Products Where Name= '" + name + "'";
            SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand(query, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = await command.ExecuteReaderAsync();
            return null;
        }

        public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}