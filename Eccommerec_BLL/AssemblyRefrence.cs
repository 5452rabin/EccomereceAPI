using AutoMapper;
using Eccommerec_BLL.Abstraction;
using Eccommerec_BLL.GenericRepository.Implementation;
using Eccommerec_BLL.GenericRepository.Interface;
using Eccommerec_BLL.Services.Implementation;
using Eccommerec_BLL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerec_BLL
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ICategoryPhotoService,CategoryPhotoService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IProductPhotoService,ProductPhotoService>();
            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<ICustomerService,CustomerService>();
            return services;
        }
    }
}

