using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Models.DTO
{
	public class CategoryDto : BaseModelDto
	{
		public virtual List<Product?> Products { get; set; } = new List<Product>();

	}
}
