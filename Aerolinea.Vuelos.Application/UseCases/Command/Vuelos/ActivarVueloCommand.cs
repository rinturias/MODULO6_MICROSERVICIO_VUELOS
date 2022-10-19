using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class ActivarVueloCommand : IRequest<ResulService> {
        private ActivarVueloCommand() { }

        public ActivarVueloCommand(RequestVueloActivadoDTO detalle) {
            Detalle = detalle;
        }

        public RequestVueloActivadoDTO Detalle { get; set; }



    }
}
