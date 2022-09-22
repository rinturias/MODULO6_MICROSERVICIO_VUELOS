using System;

namespace Aerolinea.Vuelos.Application.Dto {
    public class RequestVueloDto {
        public DateTime horaSalida { get; set; }
        public DateTime horaLLegada { get; set; }
        public string estado { get; set; }
        public decimal precio { get; set; }
        public int StockAsientos { get; set; }
        public DateTime fecha { get; set; }
        public Guid codRuta { get; set; }
        public Guid codAeronave { get; set; }
        //public int activo { get; set; }

        //public List<TripulacionDto> tripulaciones { get; set; }
    }
}
