using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;

namespace Aerolinea.Vuelos.Application.Dto {
    [ExcludeFromCodeCoverage]
    public class VuelosDto {
        public Guid codVuelo { get; set; }
        public DateTime horaSalida { get; set; }
        public DateTime horaLLegada { get; set; }
        public string estado { get; set; }
        public decimal precio { get; set; }
        public int StockAsientos { get; set; }
        public DateTime fecha { get; set; }
        public Guid codRuta { get; set; }
        public Guid codAeronave { get; set; }
        public int activo { get; set; }

        public List<TripulacionDto> tripulaciones { get; set; }


    }
}
