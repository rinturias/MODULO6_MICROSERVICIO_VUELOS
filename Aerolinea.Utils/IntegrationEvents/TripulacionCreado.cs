using System;
using Sharedkernel.Core;

namespace Sharedkernel.IntegrationEvents {
    public record TripulacionCreado : IntegrationEvent {
        public Guid vueloId { get; set; }
        public Guid codTripulacion { get; set; }
        public Guid codEmpleado { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }
    }
}
