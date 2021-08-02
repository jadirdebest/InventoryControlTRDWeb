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
            services.AddTransient(typeof(IDataCore<>), typeof(DataCore<>));
            services.AddSingleton<IAppSecurityService, AppSecurityService>();

            AddProductService(services);
            AddSubProductService(services);
            AddInventoryService(services);
            AddMovimentService(services);
            AddMovimentProductService(services);
            AddAccountService(services);
            AddReportService(services);

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
        public static void AddInventoryService(this IServiceCollection services)
        {
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IAppInventoryService, AppInventoryService>();
        }
        public static void AddMovimentService(this IServiceCollection services)
        {
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAppRequestService, AppRequestService>();
        }
        public static void AddMovimentProductService(this IServiceCollection services)
        {
            services.AddScoped<IRequestProductRepository, RequestProductRepository>();
            services.AddScoped<IRequestProductService, RequestProductService>();
        }
        public static void AddAccountService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAppAccountService, AppAccountService>();
        }
        public static void AddReportService(this IServiceCollection services)
        {
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAppReportService, AppReportServices>();
        }
    }
}
