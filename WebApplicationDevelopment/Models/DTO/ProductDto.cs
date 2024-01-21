using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Models.DTO
{
	public class ProductDto : BaseModelDto
	{
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public virtual Category? Category { get; set; }
		public int StoreId { get; set; }
		public virtual Store? Store { get; set; }
	}
}
