using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Services
{
	public class ProductService : IEntityService<ProductDto>
	{
		private readonly MyContext _myContext;
		private readonly IMapper _mapper;

		public ProductService(MyContext myContext, IMapper mapper)
		{
			_myContext = myContext;
			_mapper = mapper;
		}

		public bool DeleteEntity(int id)
		{
			using (_myContext)
			{
				var product = _myContext.Products.FirstOrDefault(x => x.Id == id);
				if (product != null)
				{
					_myContext.Products.Remove(product);			

					_myContext.SaveChanges();

					return true;
				}
				return false;
			}
		}

		public ProductDto? GetEntity(int id)
		{
			using (_myContext)
			{
				return _mapper.Map<ProductDto>(_myContext.Products.FirstOrDefault(x => x.Id == id));				
			}
		}

		public IEnumerable<ProductDto> GetEntitys()
		{
			using (_myContext)
			{
				return _myContext.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
			}
		}

		public void SaveEntity(ProductDto product)
		{
			using (_myContext)
			{
				if (product.Id == default)
				{
					_myContext.Entry(_mapper.Map<Category>(product)).State = EntityState.Added;
				}
				else
				{
					_myContext.Entry(_mapper.Map<Category>(product)).State = EntityState.Modified;
				}
				_myContext.SaveChanges();
			}
		}
	}
}
