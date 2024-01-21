using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Services
{
	public class CategoryService : IEntityService<CategoryDto>
	{
		private readonly MyContext _myContext;
		private readonly IMapper _mapper;
		public CategoryService(MyContext myContext, IMapper mapper)
		{
			_myContext = myContext;
			_mapper = mapper;
		}
		public IEnumerable<CategoryDto> GetEntitys()
		{
			using (_myContext)
			{
				return _myContext.Categorys.Select(x => _mapper.Map<CategoryDto>(x)).ToList();
			}
		}
		public bool DeleteEntity(int id)
		{
			using (_myContext)
			{
				var category = _myContext.Categorys.FirstOrDefault(x => x.Id == id);
				if (category != null)
				{
					_myContext.Categorys.Remove(category);

					_myContext.Products.Where(x => x.CategoryId == id).ToList()
						.ForEach(x =>
						{
							x.CategoryId = null;
							x.Category = null;
						});

					_myContext.SaveChanges();

					return true;
				}
				return false;
			}
		}		
		public CategoryDto? GetEntity(int id)
		{
			using (_myContext)
			{
				return _mapper.Map<CategoryDto>(_myContext.Categorys.FirstOrDefault(x => x.Id == id));
			}
		}
		public void SaveEntity(CategoryDto category)
		{
			using (_myContext)
			{
				if(category.Id == default)
				{
					_myContext.Entry(_mapper.Map<Category>(category)).State = EntityState.Added; 
				}
				else
				{
					_myContext.Entry(_mapper.Map<Category>(category)).State = EntityState.Modified;
				}
				_myContext.SaveChanges();
			}
		}
	}
}
