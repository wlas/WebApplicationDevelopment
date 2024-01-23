using WebApplicationDevelopment.Models.Entities;

namespace ApiGW
{
	public interface IStorageService
	{
		List<Product> GetProducts(int storageId);
	}
}
