using InventoryControlTRD.CrossCutting.AutoMapper;
using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryControlTRD.CrossCutting.Extensions.Ioc
{
    public static class IocInjectorExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
        }

        //public static void AddProductService(this IServiceCollection services)
        //{
        //    services.AddScoped<IProductRepository, ProductRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
        //public static void AddInventoryService(this IServiceCollection services)
        //{
        //    services.AddScoped<IInventoryRepository, InventoryRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
        //public static void AddProductService(this IServiceCollection services)
        //{
        //    services.AddScoped<IProductRepository, IProductRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
        //public static void AddProductService(this IServiceCollection services)
        //{
        //    services.AddScoped<IProductRepository, IProductRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
    }
}
