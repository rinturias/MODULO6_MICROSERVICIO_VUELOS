using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class CrearTripulanteCommand : IRequest<ResulService> {
        private CrearTripulanteCommand() { }

        public CrearTripulanteCommand(TripulacionDto detalle) {
            Detalle = detalle;
        }

        public TripulacionDto Detalle { get; set; }
    }
}
