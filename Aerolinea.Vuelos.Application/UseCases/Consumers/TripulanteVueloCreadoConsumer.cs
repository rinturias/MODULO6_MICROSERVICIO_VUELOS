using System.Threading.Tasks;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using MassTransit;
using MediatR;
using Sharedkernel.IntegrationEvents;

namespace Aerolinea.Vuelos.Application.UseCases.Consumers {
    public class TripulanteVueloCreadoConsumer : IConsumer<TripulacionCreado> {
        private readonly IMediator _mediator;
        public const string ExchangeName = "tripulacion-creado-exchange";
        public const string QueueName = "TripulanteVueloCreado";

        public TripulanteVueloCreadoConsumer(IMediator mediator) {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<TripulacionCreado> context) {
            TripulacionCreado @event = context.Message;

            TripulacionDto tripulacionDto = new() {
                codVuelo = @event.vueloId,
                codEmpleado = @event.codEmpleado,
                codTripulacion = @event.codTripulacion,
                activo = @event.activo,
                estado = @event.estado,

            };

            CrearTripulanteCommand command = new CrearTripulanteCommand(tripulacionDto);

            await _mediator.Send(command);

        }
    }
}
