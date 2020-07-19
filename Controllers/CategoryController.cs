using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactInventorySystem.Dtos;
using ReactInventorySystem.Models;
using ReactInventorySystem.Services;

namespace ReactInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;
        private readonly IProduct product;
        public CategoryController(ICategory category, IProduct product)
        {
            this.category = category;
            this.product = product;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = category.GetCategories();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = category.GetCategory(id);
            if (entity == null)
            {
                return NotFound();
            }
            var choiceid = entity.Id;
            // entity.Products = product.GetProductsByCategory(choiceid);
            var dto = new CategoryViewModel();
            dto.CategoryName = entity.CategoryName;
            dto.Id = entity.Id;
            
            return Ok(new Response<CategoryViewModel> {
                Success = true,
                Data = dto,
                Message = "item found"
            });
        }
        [HttpPost]
        public IActionResult Create([FromBody]Category obj)
        {
            if (ModelState.IsValid)
            {
                category.Create(obj);

                return Ok(new Response<Category>
                {
                    Data = obj,
                    Message = $"The Category {obj} has been created",
                    Success = true
                });
            }
            return BadRequest(new Response<Category>
            {
                Success = false,
                Message = "There is a problem with the submissions"
            });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            category.Delete(id);
            return Ok(new Response<Category>
            {
                Success=true,
                Message = "The item has been deleted"
            });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int? id, Category obj)
        {
            if (id == null)
            {
                return NotFound();
            }
            category.Update(id, obj);
            return Ok(new Response<Category>
            {
                Success = true,
                Message = $" The Category of id: {id} has been Updated to {obj}"
            });
        }
        
    }
}