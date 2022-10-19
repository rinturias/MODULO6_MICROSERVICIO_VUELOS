using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Tripulantes {
    public class CrearTripulanteCommand : IRequest<ResulService> {
        private CrearTripulanteCommand() { }

        public CrearTripulanteCommand(TripulacionVueloDto detalle) {
            Detalle = detalle;
        }

        public TripulacionVueloDto Detalle { get; set; }
    }
}
