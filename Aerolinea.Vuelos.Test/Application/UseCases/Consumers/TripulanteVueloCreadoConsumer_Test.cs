using Aerolinea.Vuelos.Application.UseCases.Consumers;
using MassTransit;
using MediatR;
using Moq;
using Sharedkernel.IntegrationEvents;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Consumers {
    public class TripulanteVueloCreadoConsumer_Test {

        private readonly Mock<IMediator> _mediator;
        public TripulanteVueloCreadoConsumer_Test() {
            _mediator = new Mock<IMediator>();

        }

        [Fact]
        public void TripulanteVueloCreadoConsumer_Success() {
            var context = Mock.Of<ConsumeContext<TripulacionCreado>>(_ => _.Message == MockFactory.GetTripulanteCreadoEventConsumer());
            TripulacionCreado @event = context.Message;
            var objHandler = new TripulanteVueloCreadoConsumer(
                _mediator.Object
             );

            var result = objHandler.Consume(context);
            Assert.Equal(System.Threading.Tasks.Task.CompletedTask, result);
        }


    }
}
