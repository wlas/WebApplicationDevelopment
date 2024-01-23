using WebApplicationDevelopment;
using WebApplicationDevelopment.Models.Entities;

namespace ApiGW
{
	public class StorageService : IStorageService
	{
		private readonly MyContext _context;
		public StorageService(MyContext context)
		{
			_context = context;
		}

		public List<Product> GetProducts(int storageId)
		{
			var products = new List<Product>();
			using (_context)
			{
				products.AddRange(_context.Storages.FirstOrDefault(x => x.Id == storageId).Products.ToList());
				return products;
			}
		}
	}
}
