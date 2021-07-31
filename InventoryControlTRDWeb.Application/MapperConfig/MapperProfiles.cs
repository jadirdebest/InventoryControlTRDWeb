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

            CreateMap<InventoryDto, Inventory>();
            CreateMap<InventoryDto, Inventory>();
        }
    }
}
