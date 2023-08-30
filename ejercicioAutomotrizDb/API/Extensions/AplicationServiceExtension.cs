using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions;

public static class AplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }    
}
