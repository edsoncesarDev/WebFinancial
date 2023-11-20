
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFinancial.Application.IServiceApplication;
using WebFinancial.Application.Mappings;
using WebFinancial.Application.ServiceApplication;
using WebFinancial.Data.Context;
using WebFinancial.Data.IRepositoryPattern;
using WebFinancial.Data.RepositoryPattern;

namespace WebFinancial.CrossCutting;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddDependencyInjectionAPI(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IFaturaService, FaturaService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAutoMapper(typeof(MappingsProfile));

        return services;
    }
}
