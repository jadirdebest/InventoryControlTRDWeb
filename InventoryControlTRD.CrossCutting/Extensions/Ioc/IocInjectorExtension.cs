using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Services;
using InventoryControlTRD.Infrastructure.Data.Core;
using InventoryControlTRD.Infrastructure.Data.Repositories;
using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryControlTRD.CrossCutting.Extensions.Ioc
{
    public static class IocInjectorExtension
    {
        public static void AddEssentialsServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDataCore<>), typeof(DataCore<>));
            AddProductService(services);
            AddSubProductService(services);
            //AddInventoryService(services);
        }

        public static void AddProductService(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAppProductService, AppProductService>();
        }

        public static void AddSubProductService(this IServiceCollection services)
        {
            services.AddScoped<ISubProductRepository, SubProductRepository>();
            services.AddScoped<ISubProductService, SubProductService>();
            services.AddScoped<IAppSubProductService, AppSubProductService>();
        }
        //public static void AddInventoryService(this IServiceCollection services)
        //{
        //    services.AddScoped<IInventoryRepository, InventoryRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
        //public static void AddMovimentService(this IServiceCollection services)
        //{
        //    services.AddScoped<IProductRepository, IProductRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
        //public static void AddUsertService(this IServiceCollection services)
        //{
        //    services.AddScoped<IProductRepository, IProductRepository>();
        //    services.AddScoped<IProductService, ProductService>();
        //}
    }
}
