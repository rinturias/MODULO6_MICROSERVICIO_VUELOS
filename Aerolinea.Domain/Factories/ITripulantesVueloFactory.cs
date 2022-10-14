using System;
using Aerolinea.Vuelos.Domain.Entities;

namespace Aerolinea.Vuelos.Domain.Factories {
    internal interface ITripulantesVueloFactory {

        TripulacionVuelo Create(Guid codTripulacion, Guid codEmpleado, string estado, int activo, Guid vueloId, string codGrupo);

    }
}
