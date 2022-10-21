using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class ReprogramarVueloCommand : IRequest<ResulService> {
        private ReprogramarVueloCommand() { }

        public ReprogramarVueloCommand(RequestVueloReprogramadoDTO detalle) {
            Detalle = detalle;
        }

        public RequestVueloReprogramadoDTO Detalle { get; set; }


    }
}
