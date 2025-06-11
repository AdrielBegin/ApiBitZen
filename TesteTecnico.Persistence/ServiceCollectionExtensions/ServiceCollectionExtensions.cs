using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteTecnico.Domain.Interfaces;
using TesteTecnico.Persistence.Contexto;
using TesteTecnico.Persistence.Repositorio;

namespace TesteTecnico.Persistence.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ISalaRepositorio, SalaRepositorio>();
            services.AddScoped<IReservaRepositorio, ReservaRepositorio>();

            return services;
        }
    }
}
