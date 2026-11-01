using Todo.Application.Interfaces.Workers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Reflection;


namespace Todo.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            


            //services.AddHostedService<LogJobBackground>();
            //services.AddHostedService<LogDbBackground>();
            //services.AddHostedService<LogHttpBackground>();
            //services.AddHostedService<AuditHttpBackground>();
            //services.AddHostedService<AuditEndpointBackground>();
            return services;
        }


        


    }
}