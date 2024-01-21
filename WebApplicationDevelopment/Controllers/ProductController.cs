using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;

namespace WebApplicationDevelopment.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : Controller
	{
		private readonly IEntityService<ProductDto> _productService;
		public ProductController(IEntityService<ProductDto> productService)
		{
			_productService = productService;
		}

		[HttpGet("getProduct")]
		public IActionResult GetProducts()
		{
			var response = _productService.GetEntitys();
			return Ok(response);
		}

		[HttpGet("product/{id}")]
		public IActionResult GetProduct(int id)
		{
			ProductDto product = _productService.GetEntity(id);
			return Ok(product);
		}

		[HttpPost("addProduct")]
		public IActionResult PutProducts([FromQuery] string name, string description, decimal price, int categoryId, int storeId)
		{
			try
			{
				ProductDto productDto = new ProductDto()
				{
					Name = name,
					Description = description,
					Price = price,
					CategoryId = categoryId,
					StoreId = storeId
				};
				_productService.SaveEntity(productDto);
				return Ok();
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
		}

		[HttpDelete("productId")]
		public IActionResult DeleteProduct(int productId)
		{
			if (!_productService.DeleteEntity(productId))
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
