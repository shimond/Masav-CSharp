using MasavWebApi.Contracts;
using MasavWebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MasavWebApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<ProductDto>))]
        public IHttpActionResult GetAllProducts()
        {
            

            s.AddProduct(new Models.Product { Id = 2 });
            var products = new List<string> { "Product1", "Product2", "Product3" };
            return Ok(products);
        }


    }
}
