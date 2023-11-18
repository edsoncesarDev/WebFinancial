
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFinancial.Application.Mappings;
using WebFinancial.Data.Context;

namespace WebFinancial.CrossCutting;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddDependencyInjectionAPI(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(configuration.GetConnectionString("Cennection")));

        services.AddAutoMapper(typeof(MappingsProfile));

        return services;
    }
}
