using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;

namespace WebApplicationDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : Controller
    {
		private readonly IEntityService<StoreDto> _storeService;
		public StoreController(IEntityService<StoreDto> storeService)
		{
			_storeService = storeService;
		}

		[HttpGet("getStore")]
		public IActionResult GetStories()
		{
			var response = _storeService.GetEntitys();
			return Ok(response);
		}

		[HttpGet("store/{id}")]
		public IActionResult GetStore(int id)
		{
			StoreDto store = _storeService.GetEntity(id);
			return Ok(store);
		}

		[HttpPost("addStore")]
		public IActionResult PutStore([FromQuery] string name, string description)
		{
			try
			{
				StoreDto storeDto = new StoreDto()
				{
					Name = name,
					Description = description
				};
				_storeService.SaveEntity(storeDto);
				return Ok();
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
		}

		[HttpDelete("storeId")]
		public IActionResult DeleteStore(int storeId)
		{
			if (!_storeService.DeleteEntity(storeId))
			{
				return Ok();
			}
			else
			{
				return StatusCode(500);
			}
		}
	}
}
