using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactInventorySystem.Services;

namespace ReactInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategory serv;
        public CategoryProductController(ICategory serv)
        {
            this.serv = serv;
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryProducts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var res = serv.GetCategoryProducts(id);
            return Ok(res);
        }
    }
}