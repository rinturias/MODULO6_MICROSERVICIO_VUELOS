using System;
using Aerolinea.Vuelos.Domain.Entities;

namespace Aerolinea.Vuelos.Domain.Factories {
    public class TripulantesVueloFactory : ITripulantesVueloFactory {
        public TripulacionVuelo Create(Guid codTripulacion, Guid codEmpleado, string estado, int activo, Guid vueloId, string codGrupo) {
            return new TripulacionVuelo(codTripulacion, codEmpleado, estado, activo, vueloId, codGrupo);
        }
    }
}
