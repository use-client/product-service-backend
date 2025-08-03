using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> products =
        [
            new Product { Id = "1", Name = "Laptop", Description = "High performance laptop", Price = 999.99m, Category = "Electronics", StockQuantity = 50 },
            new Product { Id = "2", Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, Category = "Electronics", StockQuantity = 100 },
            new Product { Id = "3", Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, Category = "Accessories", StockQuantity = 200 }
        ];

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
    }
}