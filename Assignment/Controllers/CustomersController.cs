using Assignment.Contexts;
using Assignment.Models;
using Assignment.Models.Entities;
using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model) //skapar en kund
        {
            if (ModelState.IsValid) //kontrollerar att fälten är i fyllda
            {
                await _customerService.Create(model);   
                return new OkResult();
            } 
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() //hämtar alla kunder
        {

            return new OkObjectResult(await _customerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get (int id)
        {
            var result = await _customerService.get(id);
            if(result != null) 
            return new OkObjectResult(result);
            return new NotFoundResult();
        
        }    
    }
}
