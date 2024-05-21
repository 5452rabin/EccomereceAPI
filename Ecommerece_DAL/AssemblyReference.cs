using Ecommerece_DAL.Context;
using Ecommerece_DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerece_DAL
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EccomereceDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            

            return services;
        }
    }
}
