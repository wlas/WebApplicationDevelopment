using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;

namespace WebApplicationDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
		private readonly IEntityService<CategoryDto> _categoryService;
		public CategoryController(IEntityService<CategoryDto> categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("getCategory")]
		public IActionResult GetCategorys()
		{
			var response = _categoryService.GetEntitys();
			return Ok(response);
		}

		[HttpGet("category/{id}")]
		public IActionResult GetCategory(int id)
		{
			CategoryDto category = _categoryService.GetEntity(id);
			return Ok(category);
		}

		[HttpPost("addCategory")]
		public IActionResult PutCategory([FromQuery] string name, string description)
		{
			try
			{
				CategoryDto categoryDto = new CategoryDto()
				{
					Name = name,
					Description = description					
				};
				_categoryService.SaveEntity(categoryDto);
				return Ok();
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
		}

		[HttpDelete("categoryId")]
		public IActionResult DeleteCategory(int categoryId)
		{
			if (!_categoryService.DeleteEntity(categoryId))
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
