using Todo.Application.Interfaces.Repositories;
using Todo.Application.Models.Common;

using Todo.Infrastructure.Persistence;
using Todo.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web;

namespace Todo.Infrastructure
{
    public static class Extensions
    {

        /// <summary>
        /// Agregamos la infraestructura de la aplicación.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <param name="IsLocal"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration, bool IsLocal)
        {

            services.AddDbContext<BaseDbContext>(opstions =>
            {
                opstions.UseSqlServer(Configuration.GetConnectionString("DEV_STANDAR"));
                if (IsLocal)
                {
                    opstions.LogTo(Console.WriteLine, LogLevel.Information)
                            .EnableSensitiveDataLogging();
                }
            });

            //agregamos todos los repositoprios genéricos en una sola linea.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITodoRepository, TodoRepository>();


            //TODO: Solo sirve de ejemplo de errores


            return services;
        }


    }
}
