using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Models.DTO
{
	public class StoreDto : BaseModelDto
	{
		public virtual List<ProductDto?> Products { get; set; }
	}
}
