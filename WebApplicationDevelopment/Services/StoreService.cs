using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationDevelopment.Interfaces;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Models.Entities;

namespace WebApplicationDevelopment.Services
{
	public class StoreService : IEntityService<StoreDto>
	{
		private readonly MyContext _myContext;
		private readonly IMapper _mapper;
		public StoreService(MyContext myContext, IMapper mapper)
		{
			_myContext = myContext;
			_mapper = mapper;
		}

		public bool DeleteEntity(int id)
		{
			using (_myContext)
			{
				var store = _myContext.Storages.FirstOrDefault(x => x.Id == id);
				if (store != null)
				{
					_myContext.Storages.Remove(store);
					return true;
				}
				return false;
			}
		}

		public StoreDto? GetEntity(int id)
		{
			using (_myContext)
			{
				return _mapper.Map<StoreDto>(_myContext.Storages.FirstOrDefault(x => x.Id == id));
			}
		}

		public IEnumerable<StoreDto> GetEntitys()
		{
			using (_myContext)
			{
				return _myContext.Storages.Select(x => _mapper.Map<StoreDto>(x)).ToList();
			}
		}

		public void SaveEntity(StoreDto storeDto)
		{
			using (_myContext)
			{
				if (storeDto.Id == default)
				{
					_myContext.Entry(_mapper.Map<Store>(storeDto)).State = EntityState.Added;
				}
				else
				{
					_myContext.Entry(_mapper.Map<Store>(storeDto)).State = EntityState.Modified;
				}
				_myContext.SaveChanges();
			}
		}
	}
}
