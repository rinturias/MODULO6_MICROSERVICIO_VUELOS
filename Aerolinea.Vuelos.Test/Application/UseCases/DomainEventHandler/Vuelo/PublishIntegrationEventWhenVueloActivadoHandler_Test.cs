using System.Threading;
using Aerolinea.Vuelos.Application.UseCases.DomainEventHandler.Vuelo;
using Aerolinea.Vuelos.Domain.Event;
using MassTransit;
using MediatR;
using Moq;
using Sharedkernel.Core;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.DomainEventHandler.Vuelo {
    public class PublishIntegrationEventWhenVueloActivadoHandler_Test {

        private readonly Mock<IPublishEndpoint> _mediator;
        private Mock<ConfirmedDomainEvent<VueloReprogramado>> _reprogramcion;
        private Mock<PublishIntegrationEventWhenVueloReprogramadoHandler> _handle;
        public PublishIntegrationEventWhenVueloActivadoHandler_Test() {
            _mediator = new Mock<IPublishEndpoint>();
            _reprogramcion = new Mock<ConfirmedDomainEvent<VueloReprogramado>>();
        }

        [Fact]
        public async void PublishIntegrationEventWhenVueloActivadoHandler_Success() {

            _mediator.Setup(m => m.Publish(It.IsAny<ConfirmedDomainEvent<VueloReprogramado>>(), It.IsAny<CancellationToken>()))
            .Returns(MockFactory.GetVueloReprogrmadoShareKernel())
            .Verifiable("Notification was not sent.");

            var objHandler = new PublishIntegrationEventWhenVueloReprogramadoHandler(
               _mediator.Object
            );

            var tcs = new CancellationTokenSource(1000);








         

        }
    }
}
