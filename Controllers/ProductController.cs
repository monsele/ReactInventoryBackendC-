using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactInventorySystem.Data;
using ReactInventorySystem.Models;
using ReactInventorySystem.Services;

namespace ReactInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct serv;
        public ProductController(IProduct serv)
        {
            this.serv = serv;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = serv.GetProducts();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound(new Response<Product>
                {
                    Message = $"The product of id: {id} cannot be found",
                    Success = false
                });
            }
            var entity = serv.GetProduct(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(new Response<Product>
            {
                Success = true,
                Data = entity,
                Message = "item found"
            });
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                serv.CreateProduct(product);
                return Ok(new Response<Product>
                {
                    Data = product,
                    Success = true,
                    Message = $"The product {product.ProductName} has been Created"
                });

            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(new Response<Product> { Message="The Item cannot be found pls refresh the page" });
            }
            serv.DeleteProduct(id);
            return Ok(new Response<Product> { Success = true, Message = "The operation was Successful" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int? id, Product product)
        {
            if (ModelState.IsValid)
            {
                serv.Update(id, product);
                return Ok(new Response<Product>
                {
                    Success = true,
                    Message = "Product has been updated"
                });
            }
            return BadRequest();
        }
    }
}