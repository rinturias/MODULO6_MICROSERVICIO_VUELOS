using System.Threading;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Event;
using MassTransit;
using MediatR;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Application.UseCases.DomainEventHandler.Vuelo {
    public class PublishIntegrationEventWhenVueloCreadoHandler : INotificationHandler<ConfirmedDomainEvent<VueloHabilitado>> {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenVueloCreadoHandler(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<VueloHabilitado> notification, CancellationToken cancellationToken) {

            Sharedkernel.IntegrationEvents.VueloHabilitado evento = new Sharedkernel.IntegrationEvents.VueloHabilitado() {
                vueloId = notification.DomainEvent.vueloHabilitado.Id,
                codAeronave = notification.DomainEvent.vueloHabilitado.codAeronave,
                codRuta = notification.DomainEvent.vueloHabilitado.codRuta,
                precio = notification.DomainEvent.vueloHabilitado.precio.Value,
                stockAsientos = notification.DomainEvent.vueloHabilitado.stockAsientos,
                fecha = notification.DomainEvent.vueloHabilitado.fecha,
                horaLLegada = notification.DomainEvent.vueloHabilitado.horaLLegada,
                horaSalida = notification.DomainEvent.vueloHabilitado.horaSalida,
                estado = notification.DomainEvent.vueloHabilitado.estado,
            };
            await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.VueloHabilitado>(evento);


        }
    }
}
