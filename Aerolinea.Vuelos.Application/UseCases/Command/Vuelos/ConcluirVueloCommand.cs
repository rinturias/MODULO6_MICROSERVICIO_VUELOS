using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class ConcluirVueloCommand : IRequest<ResulService> {
        private ConcluirVueloCommand() { }

        public ConcluirVueloCommand(RequestConcludeFlightDTO detalle) {
            Detalle = detalle;
        }

        public RequestConcludeFlightDTO Detalle { get; set; }



    }
}
