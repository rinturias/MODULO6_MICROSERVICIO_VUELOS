using System;

namespace Aerolinea.Vuelos.Application.Dto.Tripulantes {
    public class TripulacionDto {

        public Guid codVuelo { get; set; }
        public Guid codTripulacion { get; set; }
        public Guid codEmpleado { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }


    }
}
