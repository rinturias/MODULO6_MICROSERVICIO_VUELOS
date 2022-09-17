using System;

namespace Aerolinea.Vuelos.Application.Dto {
    public class RequestConcludeFlightDTO {

        public Guid CodVuelo { get; set; }
        public string estado { get; set; }
    }
}
