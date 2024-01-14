using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("getProduct")]
        public IActionResult GetProducts()
        {
            try
            {
                using (var context = new MyContext())
                {
                    var products = context.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).ToList();

                    return Ok(products);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("putProduct")]
        public IActionResult PutProducts([FromQuery] string name, string description, int categoryId, int storeID, decimal price)
        {
            try
            {
                using (var context = new MyContext())
                {
                    if (!context.Products.Any(x => x.Name.ToLower().Equals(name)))
                    {
                        context.Products.Add(new Product()
                        {
                            Name = name,
                            Description = description,
                            CategoryId = categoryId,
                            Price = price,
                            StoreId = storeID
                        });
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpDelete("productId")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                using (var context = new MyContext())
                {
                    Product? product = context.Products.FirstOrDefault(x => x.Id == productId);

                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
