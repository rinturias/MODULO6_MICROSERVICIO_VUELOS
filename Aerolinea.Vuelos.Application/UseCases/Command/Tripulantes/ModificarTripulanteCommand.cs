using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Tripulantes {
    internal class ModificarTripulanteCommand : IRequest<ResulService> {
        private ModificarTripulanteCommand() { }

        public ModificarTripulanteCommand(TripulacionVueloDto detalle) {
            Detalle = detalle;
        }

        public TripulacionVueloDto Detalle { get; set; }
    }
}