using Assignment.Contexts;
using Assignment.Models;
using Assignment.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task Create(OrderModel orderModel)
        {
            var orderEntity = new OrderEntity
            {
                OrderDate = DateTime.Now,
                DueDate= DateTime.Now,
                Id = orderModel.CustomerId,
                CustomerName = orderModel.CustomerName,
                City = orderModel.City,
                StreetName= orderModel.StreetName,
                PostalCode= orderModel.PostalCode,
                
            };
            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            foreach (var product in orderModel.Products)
            {
                _context.OrderRows.Add(new OrderRowEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = product.Id
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
