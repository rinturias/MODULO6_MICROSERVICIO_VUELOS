using System.Threading;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Event;
using MassTransit;
using MediatR;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Application.UseCases.DomainEventHandler.Vuelo {
    public class PublishIntegrationEventWhenVueloReprogramadoHandler : INotificationHandler<ConfirmedDomainEvent<VueloReprogramado>> {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenVueloReprogramadoHandler(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }



        public async Task Handle(ConfirmedDomainEvent<VueloReprogramado> notification, CancellationToken cancellationToken) {
            Sharedkernel.IntegrationEvents.VueloReprogramado evento = new Sharedkernel.IntegrationEvents.VueloReprogramado() {
                vueloId = notification.DomainEvent.vueloReprogramado.Id,
                horaSalida = notification.DomainEvent.vueloReprogramado.horaSalida,
                horaLlegada = notification.DomainEvent.vueloReprogramado.horaLLegada,
                fecha = notification.DomainEvent.vueloReprogramado.fecha.ToString("dd/MM/yyyy"),
                codAeronave = notification.DomainEvent.vueloReprogramado.codAeronave
            };
            await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.VueloReprogramado>(evento);
        }
    }
}
