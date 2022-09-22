using System;

namespace Sharedkernel.Entidades {
    public class Tripulacion {


        public Guid vueloId { get; set; }
        public Guid codTripulacion { get; set; }
        public Guid codEmpleado { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }
    }
}
