using System;
using System.Threading;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Event;
using MassTransit;
using MediatR;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Application.UseCases.DomainEventHandler.Vuelo {
    public class PublishIntegrationEventWhenVueloActivadoHandler : INotificationHandler<ConfirmedDomainEvent<VueloActivado>> {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenVueloActivadoHandler(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }



        public async Task Handle(ConfirmedDomainEvent<VueloActivado> notification, CancellationToken cancellationToken) {
            Sharedkernel.IntegrationEvents.VueloActivado evento = new Sharedkernel.IntegrationEvents.VueloActivado() {
                vueloId = notification.DomainEvent.vueloActivado.Id,
                fecha = DateTime.Now.ToString("dd/MM/yyyy")
            };
            await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.VueloActivado>(evento);
        }
    }
}