using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationMVC.REST.Models;

namespace WebApplicationMVC.REST.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly Product[] products = new Product[]
            {
                new Product
                {
                    Id = "9acc5bbb-1ff9-41d5-a6f2-eb4748fa0fa4",
                    Name = "Product 1",
                    Price = 1.25,
                    Exists = false,
                    Issued = null
                },
                new Product
                {
                    Id = "a800eba4-c3a7-4b5e-ab58-26e112782122",
                    Name = "Product 1",
                    Price = 1.25,
                    Exists = true,
                    Issued = DateTime.UtcNow
                }
            };

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET: api/Products/5
        //[Route("api/products/{id:guid}")]
        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var result = products
                .FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product value)
        {
            if (value == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            value.Id = Guid.NewGuid().ToString();
            var url = Url.Route("DefaultApi", new { controller = "products", id = value.Id });
            return Created(url, value);
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(string id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
