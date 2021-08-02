using AutoMapper;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRDWeb.Application.Dto;

namespace InventoryControlTRDWeb.Application.MapperConfig
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<SubProduct, SubProductDto>();
            CreateMap<SubProductDto, SubProduct>();

            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryDto, Inventory>();

            CreateMap<Request, RequestDto>();
            CreateMap<RequestDto, Request>();

            CreateMap<RequestProduct, RequestProductDto>();
            CreateMap<RequestProductDto, RequestProduct>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}
