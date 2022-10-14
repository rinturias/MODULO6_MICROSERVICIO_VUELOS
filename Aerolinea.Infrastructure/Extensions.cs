using System.Reflection;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.UseCases.Consumers;
using Aerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Infrastructure.EF;
using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
using Aerolinea.Vuelos.Infrastructure.Repositories;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aerolinea.Vuelos.Infrastructure {

    public static class Extensions {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString = configuration.GetConnectionString("VueloDbConnectionString");

            services.AddDbContext<ReadDbContext>(context => context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context => context.UseSqlServer(connectionString));


            services.AddScoped<IVueloRepository, VueloRepository>();
            services.AddScoped<ITripulacionVueloRepository, TripulacionVueloRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            AddRabbitMq(services, configuration);

            return services;
        }

        private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration) {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config => {
                config.AddConsumer<TripulanteVueloCreadoConsumer>().Endpoint(endpoint => endpoint.Name = TripulanteVueloCreadoConsumer.QueueName);

                config.UsingRabbitMq((context, cfg) => {
                    var uri = string.Format("amqp://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                    cfg.Host(uri);

                    cfg.ReceiveEndpoint(TripulanteVueloCreadoConsumer.QueueName, endpoint => {
                        endpoint.ConfigureConsumer<TripulanteVueloCreadoConsumer>(context);
                    });
                });
            });
        }
    }
}
