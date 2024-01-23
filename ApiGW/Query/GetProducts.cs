
using WebApplicationDevelopment.Models.Entities;

namespace ApiGW.Query
{
	public class GetProducts
	{
		public List<Product> GetProductsOnStorqage([Service] IStorageService repository, int storageId) => repository.GetProducts(storageId);
	}
}
