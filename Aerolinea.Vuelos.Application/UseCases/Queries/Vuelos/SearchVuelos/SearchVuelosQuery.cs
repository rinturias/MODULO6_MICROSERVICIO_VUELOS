using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos {
    public class SearchVuelosQuery : IRequest<ResulService> {

        public SearchVuelosQuery() { }
        public SearchVuelosDTO SearchVuelosDTO { get; set; }
    }
}
