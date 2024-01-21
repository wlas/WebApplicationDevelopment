using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Models.DTO
{
	public class StoreDto : BaseModelDto
	{
		public virtual List<Product?> Products { get; set; }
		public int Count { get; set; }
	}
}
