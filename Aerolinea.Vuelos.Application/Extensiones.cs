using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Aerolinea.Vuelos.Application.Services;
using Aerolinea.Vuelos.Domain.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aerolinea.Vuelos.Application {
    [ExcludeFromCodeCoverage]
    public static class Extensions {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IVueloServices, VueloServices>();
            services.AddTransient<IVuelosFactory, VuelosFactory>();



            return services;
        }

    }
}
