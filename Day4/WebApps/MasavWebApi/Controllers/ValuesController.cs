using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MasavWebApi.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("wow")]
        [HttpGet]
        public IEnumerable<string> Test()
        {
            //HttpContext.Current
            return new string[] { "value1", "value2" };
        }

        [Route("ById/{id}")]
        [HttpGet]
        public string RetriveById(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        [Route("{id}")]  
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        [Route("{id}")]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
