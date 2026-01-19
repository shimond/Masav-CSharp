using MasavWebApi.Contracts;
using MasavWebApi.Data;
using MasavWebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MasavWebApi.Controllers
{
    [RoutePrefix("api/products")]
    //[Authorize("Admin")]
    public class ProductsController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            //_productRepository = new Services.AdoDbProductsRepository();
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> AddNewProduct(ProductDto productDto)
        {
            var p = await _productRepository.AddProduct(new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
            });
         
            var res = new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
            };
            return Ok(res);
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<ProductDto>))]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts();  
            var resultDto = result.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
            }).ToList();
        
            return Ok(resultDto);
        }

    }
}
