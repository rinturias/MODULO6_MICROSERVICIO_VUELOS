using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class CrearVuelosCommand : IRequest<ResulService> {
        private CrearVuelosCommand() { }

        public CrearVuelosCommand(RequestVueloDto detalle) {
            Detalle = detalle;
        }

        public RequestVueloDto Detalle { get; set; }



    }
}
