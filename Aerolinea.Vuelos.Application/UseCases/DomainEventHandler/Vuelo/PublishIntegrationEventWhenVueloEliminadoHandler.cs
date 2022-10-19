using System;
using System.Threading;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Event;
using MassTransit;
using MediatR;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Application.UseCases.DomainEventHandler.Vuelo {
    public class PublishIntegrationEventWhenVueloEliminadoHandler : INotificationHandler<ConfirmedDomainEvent<VueloEliminado>> {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenVueloEliminadoHandler(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }



        public async Task Handle(ConfirmedDomainEvent<VueloEliminado> notification, CancellationToken cancellationToken) {
            Sharedkernel.IntegrationEvents.VueloEliminado evento = new Sharedkernel.IntegrationEvents.VueloEliminado() {
                vueloId = notification.DomainEvent.vueloEliminado.Id,
                fecha = DateTime.Now.ToString("dd/MM/yyyy")
            };
            await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.VueloConcluido>(evento);
        }
    }
}
