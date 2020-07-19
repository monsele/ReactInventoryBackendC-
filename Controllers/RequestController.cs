using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactInventorySystem.Models;
using ReactInventorySystem.Services;

namespace ReactInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequest serv;
        public RequestController(IRequest serv)
        {
            this.serv = serv;
        }
        [HttpGet]
        public IActionResult GetRequests()
        {
            var result = serv.GetRequests();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetRequest(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var entity = serv.GetRequest(id);
            if (entity==null)
            {
                return NotFound();
            }
            return Ok(new Response<Request>
            {
                Data = entity,
                Success = true
            });
        }

        [HttpPost]
        public IActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                serv.Create(request);
                return Ok(new Response<Request>
                {
                    Data = request,
                    Success = true,
                    Message = $"The Request has been created"
                });
            }
            return BadRequest(new Response<Request>
            {
                Message = $"Something went wrong pls try again",
                Success = false
            });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound(id);
            }
            serv.Delete(id);
            return Ok(new Response<Request>
            {
                Success = true,
                Message = $"The operation was successfull"
            });
        }

        [HttpPut("{id}")]
        public IActionResult HandleRequest([FromRoute]int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var request = serv.GetRequest(id);
            if (request==null)
            {
                return NotFound(new Response<Request> { 
                Success=false,
                Message="Operation failed"
                });
            }
            serv.handleRequest(request);
            return Ok(new Response<Request>
            {
                Success = true,
                Message = "The Request Has been taken You can come and recieve it "
            });

        }

    }
}