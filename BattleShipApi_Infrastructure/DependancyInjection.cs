using BattleShip_Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipApi_Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BattleShipApiDbContext>(options =>
             options.UseInMemoryDatabase("BattleshipDB"));

            services.AddScoped<IBattleShipApiDbContext>(provider => (IBattleShipApiDbContext)provider.GetService<BattleShipApiDbContext>());

            services.AddScoped<IBattleShipApiDbContext>(provider => (IBattleShipApiDbContext)provider.GetService<BattleShipApiDbContext>());

            return services;
        }
    }
}

