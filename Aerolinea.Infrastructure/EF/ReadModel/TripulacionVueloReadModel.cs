using System;

namespace Aerolinea.Vuelos.Infrastructure.EF.ReadModel {
    public class TripulacionVueloReadModel {
        public Guid Id { get; set; }

        public Guid codTripulacion { get; set; }
        public Guid codEmpleado { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }

        public string descripcion { get; set; }
        public string codGrupo { get; set; }

    }
}
