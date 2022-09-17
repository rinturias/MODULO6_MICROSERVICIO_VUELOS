using System;
using Aerolinea.Vuelos.Application.Dto;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos {
    public class SearchFlightByIDflightQuery : IRequest<ResulService> {

        public SearchFlightByIDflightQuery(Guid id) {
            SearchFlightDTO _searchFlightDTO = new();
            _searchFlightDTO.IdVuelo = id;
            searchFlightDTO = _searchFlightDTO;
        }
        public SearchFlightDTO searchFlightDTO { get; set; }
    }
}
