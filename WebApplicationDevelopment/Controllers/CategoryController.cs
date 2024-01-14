using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        [HttpGet("getCategory")]
        public IActionResult GetCategory()
        {
            try
            {
                using (var context = new MyContext())
                {
                    var categories = context.Categorys.Select(x => new Category()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).ToList();
                    return Ok(categories);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("putCategory")]
        public IActionResult PutCategories([FromQuery] string name, string description)
        {
            try
            {
                using (var context = new MyContext())
                {
                    if (!context.Categorys.Any(x => x.Name.ToLower().Equals(name)))
                    {
                        context.Categorys.Add(new Category()
                        {
                            Name = name,
                            Description = description
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

        [HttpDelete("categoryId")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                using (var context = new MyContext())
                {
                    Category? category = context.Categorys.FirstOrDefault(x => x.Id == categoryId);

                    if (category != null)
                    {
                        context.Categorys.Remove(category);
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
