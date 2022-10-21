using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Application.Dto {
    public class RequestVueloReprogramadoDTO {
        public Guid idVuelo { get; set; }
        public DateTime horaSalida { get; set; }
        public DateTime horaLLegada { get; set; }
        public DateTime fecha { get; set; }
        public Guid codAeronave { get; set; }
    }
}
