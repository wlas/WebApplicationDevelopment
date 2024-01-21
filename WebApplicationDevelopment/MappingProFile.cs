using AutoMapper;
using System.Text.RegularExpressions;
using WebApplicationDevelopment.Models.DTO;
using WebApplicationDevelopment.Models.Entities;

internal class MappingProFile : Profile
{
	protected MappingProFile()
	{
		CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
		CreateMap<Category, CategoryDto>(MemberList.Destination).ReverseMap();
		CreateMap<Store, StoreDto>(MemberList.Destination).ReverseMap();
	}
}