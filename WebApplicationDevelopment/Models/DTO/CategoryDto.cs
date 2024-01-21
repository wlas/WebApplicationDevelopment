using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Models.DTO
{
	public class CategoryDto : BaseModelDto
	{
		public virtual List<ProductDto?> Products { get; set; } = new List<ProductDto>();

	}
}
