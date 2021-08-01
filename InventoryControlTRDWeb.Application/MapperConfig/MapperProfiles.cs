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

            CreateMap<Moviment, MovimentDto>();
            CreateMap<MovimentDto, Moviment>();

            CreateMap<MovimentProduct, MovimentProductDto>();
            CreateMap<MovimentProductDto, MovimentProduct>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}
