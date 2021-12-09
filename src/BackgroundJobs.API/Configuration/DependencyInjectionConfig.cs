using BackgroundJobs.API.Data;
using BackgroundJobs.API.Data.Repositories;
using BackgroundJobs.API.Data.Service;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJobs.API.Configuration;

public static class DependencyInjectionConfig
{

    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServerCs")));

        services.AddTransient<ProductPopulateService>();

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
