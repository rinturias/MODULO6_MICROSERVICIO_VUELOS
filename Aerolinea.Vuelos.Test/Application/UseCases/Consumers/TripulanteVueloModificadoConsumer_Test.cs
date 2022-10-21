using Aerolinea.Vuelos.Application.UseCases.Consumers;
using MassTransit;
using MediatR;
using Moq;
using Sharedkernel.IntegrationEvents;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Consumers {
    public class TripulanteVueloModificadoConsumer_Test {

        private readonly Mock<IMediator> _mediator;
        public TripulanteVueloModificadoConsumer_Test() {
            _mediator = new Mock<IMediator>();

        }

        [Fact]
        public void TripulanteVueloCreadoConsumer_Success() {
            var context = Mock.Of<ConsumeContext<TripulacionModificado>>(_ => _.Message == MockFactory.GetTripulanteModificadoEventConsumer());
            TripulacionModificado @event = context.Message;
            var objHandler = new TripulanteVueloModificadoConsumer(
                _mediator.Object
             );

            var result = objHandler.Consume(context);
            Assert.Equal(System.Threading.Tasks.Task.CompletedTask, result);
        }
    }
}
