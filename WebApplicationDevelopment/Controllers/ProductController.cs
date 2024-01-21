using Microsoft.AspNetCore.Mvc;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Utils;

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

		[HttpGet(template:"GetProductCsv")]
		public FileContentResult GetProductCsv()
		{
			var response = _productService.GetEntitys();
			var content = FilesCSV.GetCsv(response);
			return File(new System.Text.UTF8Encoding().GetBytes(content), "text/csv", "product.csv");
		}

		[HttpGet(template: "GetProductCsvUrl")]
		public ActionResult<string> GetProductCsvUrl()
		{
			var response = _productService.GetEntitys();
			var content = FilesCSV.GetCsv(response);

			string fileName = "products" + DateTime.Now.ToString("ddMMyyyy") + ".csv";
			System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(),"StaticFiles", fileName), content);

			return "https://" + Request.Host.ToString() + "/static/" + fileName;
		}
	}
}
