using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos {
    public class SearchListVuelosQuery : IRequest<ResulService> {

        public SearchListVuelosQuery() { }

    }
}
