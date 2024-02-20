using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestTask.Data;
using TestTask.Repositories.Implementations;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

namespace TestTask.Extensions
{
    public static class ServicesInjectionExtension
    {
        public static void InjectDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void InjectBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void InjectSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "iFortexTestTask",
                    Version = "v1",
                    Description = "WebAPI for users and orders"
                });
            });
        }
    }
}
