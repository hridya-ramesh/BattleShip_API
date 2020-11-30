using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using BattleShip_Application.Common;

namespace BattleShip_Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehaviour<,>));
            return services;
        }
    }
}
