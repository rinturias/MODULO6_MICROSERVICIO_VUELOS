using System;
using System.Collections.Generic;

namespace Aerolinea.Vuelos.Application.Dto.Tripulantes {
    public class TripulacionVueloDto {

        public String IdGrupo { get; set; }
        public Guid vueloId { get; set; }
        public ICollection<TripulacionDto> tripulacionVuelos { get; set; }
    }
}
