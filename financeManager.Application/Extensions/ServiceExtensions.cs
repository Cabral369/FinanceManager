using financeManager.Application.Interfaces;
using financeManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace financeManager.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {

        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}