using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using Aerolinea.Vuelos.Application.UseCases.Command.Tripulantes;
using MassTransit;
using MediatR;
using Sharedkernel.IntegrationEvents;

namespace Aerolinea.Vuelos.Application.UseCases.Consumers {
    public class TripulanteVueloCreadoConsumer : IConsumer<TripulacionCreado> {
        private readonly IMediator _mediator;
        public const string ExchangeName = "tripulacion-creado-exchange";
        public const string QueueName = "tripulacion-creado-empleado";

        public TripulanteVueloCreadoConsumer(IMediator mediator) {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<TripulacionCreado> context) {
            TripulacionCreado @event = context.Message;
            ICollection<TripulacionDto> tripulacionVuelos = new List<TripulacionDto>();

            foreach (var item in @event.tripulacionVuelos) {

                TripulacionDto tripulacionDto1 = new TripulacionDto();
                tripulacionDto1.codTripulacion = item.codTripulacion;
                tripulacionDto1.codVuelo = item.vueloId;
                tripulacionDto1.codEmpleado = item.codEmpleado;
                tripulacionDto1.estado = item.estado;
                tripulacionVuelos.Add(tripulacionDto1);

            }


            TripulacionVueloDto tripulacionDto = new() {
                vueloId = @event.vueloId,
                IdGrupo = @event.IdGrupo,
                tripulacionVuelos = tripulacionVuelos

            };

            CrearTripulanteCommand command = new CrearTripulanteCommand(tripulacionDto);

            await _mediator.Send(command);

        }
    }
}
