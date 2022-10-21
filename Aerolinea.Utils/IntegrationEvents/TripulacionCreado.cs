using System;
using System.Collections.Generic;
using Sharedkernel.Core;
using Sharedkernel.Entidades;

namespace Sharedkernel.IntegrationEvents {
    public record TripulacionCreado : IntegrationEvent {

        public String IdGrupo { get; set; }
        public Guid vueloId { get; set; }
        public ICollection<Tripulacion> tripulacionVuelos { get; set; }

        public TripulacionCreado() {

        }
    }
}
