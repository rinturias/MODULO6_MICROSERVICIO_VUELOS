using System;

namespace Aerolinea.Vuelos.Application.Dto {
    public class PlanillaAsientosVueloDto {

        public Guid codPlanillaAsiento { get; set; }
        public string asiento { get; set; }
        public string estado { get; set; }

    }
}
