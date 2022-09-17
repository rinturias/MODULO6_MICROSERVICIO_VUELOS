using System;

namespace Aerolinea.Vuelos.Application.Dto {
    public class SearchVuelosDTO {

        public DateTime FecInicial { get; set; }

        public DateTime FecFinal { get; set; }

        public Guid CodVuelo { get; set; }


    }
}
