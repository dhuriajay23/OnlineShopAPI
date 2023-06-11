// Microsoft
using Microsoft.EntityFrameworkCore;

// Project
using OnlineShopAPI.Data;
using OnlineShopAPI.Services;

namespace OnlineShopAPI.Helper
{
    public static class DIProvider
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OnlineShopConnectionString")));
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
