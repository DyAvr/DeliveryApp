using Microsoft.Extensions.DependencyInjection;
using Versta.DeliveryApp.Application.Services;

namespace Versta.DeliveryApp.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddUseCases();
        
        services.AddScoped<IOrderService, OrderService>();

        return services;
    }
    
    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }
}