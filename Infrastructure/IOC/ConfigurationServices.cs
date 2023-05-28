using Application.Cross.Concreate;
using Application.Cross.Interface;
using Application.Services.ConcreateClass.Location;
using Application.Services.ConcreateClass.Messages;
using Application.Services.ConcreateClass.Product;
using Application.Services.ConcreateClass.User;
using Application.Services.InterfaceClass.Location;
using Application.Services.InterfaceClass.Message;
using Application.Services.InterfaceClass.Products;
using Application.Services.InterfaceClass.User;
using Domain.Entities.ProductAgg;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IOC
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddAppConfigures(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddUsersServices(this IServiceCollection services)
        {

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            return services;
        }

        public static IServiceCollection AddLocationService(this IServiceCollection services)
        {            
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }

        public static IServiceCollection AddCommonService(this IServiceCollection services)
        {
            ////Services
            services.AddScoped<IUploader, Uploader>();
            services.AddScoped<IMessageService, SmsMessageService>();


            return services;
        }
        public static IServiceCollection AddProductService(this IServiceCollection services)
        {
            ////Services
            services.AddScoped<IProductService, ProductService>();
            


            return services;
        }


    }
}