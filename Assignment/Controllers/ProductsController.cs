using Assignment.Contexts;
using Assignment.Models.Entities;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model) //skapar en kund
        {
            if (ModelState.IsValid) 
            {
                var productEntity = new ProductEntity
                {
                    Id = Guid.NewGuid(), //generar guid nummer
                    Name= model.Name,
                    Description= model.Description,
                    Price= model.Price,
                    CategoryId= model.CategoryId,
                };
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() //hämtar produkter 
        {
            var products = new List<ProductModel>();
            foreach (var product in await _context.Products.Include(x => x.Category).ToListAsync())
                products.Add(new ProductModel 
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId= product.CategoryId,
                    CategoryName = product.Category.CategoryName
                });
            return new OkObjectResult(products);
        }

    }
}
