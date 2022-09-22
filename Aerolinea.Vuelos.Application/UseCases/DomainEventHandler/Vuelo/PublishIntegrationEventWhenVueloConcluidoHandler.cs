using System;
using System.Threading;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Event;
using MassTransit;
using MediatR;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Application.UseCases.DomainEventHandler.Vuelo {
    public class PublishIntegrationEventWhenVueloConcluidoHandler : INotificationHandler<ConfirmedDomainEvent<VueloConcluido>> {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenVueloConcluidoHandler(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }



        public async Task Handle(ConfirmedDomainEvent<VueloConcluido> notification, CancellationToken cancellationToken) {
            Sharedkernel.IntegrationEvents.VueloConcluido evento = new Sharedkernel.IntegrationEvents.VueloConcluido() {
                vueloId = notification.DomainEvent.vueloConcluido.Id,
                horaLLegada = notification.DomainEvent.vueloConcluido.horaLLegada,
                horaConcluido = DateTime.UtcNow,
                estado = notification.DomainEvent.vueloConcluido.estado,
                precio = notification.DomainEvent.vueloConcluido.precio,
                fechaInicio = notification.DomainEvent.vueloConcluido.fecha.ToString("dd/MM/yyyy"),
                fechaConcluido = DateTime.Now.ToString("dd/MM/yyyy")
            };
            await _publishEndpoint.Publish<Sharedkernel.IntegrationEvents.VueloConcluido>(evento);
        }
    }
}
