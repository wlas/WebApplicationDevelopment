using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : Controller
    {
        [HttpGet("getStore")]
        public IActionResult GetStore()
        {
            try
            {
                using (var context = new MyContext())
                {
                    var stores = context.Storages.Select(x => new Store()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).ToList();
                    return Ok(stores);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("putStore")]
        public IActionResult PutStore([FromQuery] string name, string description)
        {
            try
            {
                using (var context = new MyContext())
                {
                    if (!context.Storages.Any(x => x.Name.ToLower().Equals(name)))
                    {
                        context.Storages.Add(new Store()
                        {
                            Name = name,
                            Description = description,
                            Count = 1                            
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

        [HttpDelete("storeId")]
        public IActionResult DeleteStore(int storeId)
        {
            try
            {
                using (var context = new MyContext())
                {
                    Store? store = context.Storages.FirstOrDefault(x => x.Id == storeId);

                    if (store != null)
                    {
                        context.Storages.Remove(store);
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
