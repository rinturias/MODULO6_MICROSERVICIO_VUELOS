using System;
using System.Collections.Generic;

namespace Aerolinea.Vuelos.Infrastructure.EF.ReadModel {
    public class VueloReadModel {
        public Guid Id { get; set; }
        public DateTime horaSalida { get; set; }
        public DateTime horaLLegada { get; set; }
        public string estado { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public Guid codRuta { get; set; }
        public Guid codAeronave { get; set; }
        public int activo { get; set; }
        public int stockAsientos { get; set; }
        public string? codGrupoTripulacion { get; set; }
        public string? horaConcluido { get; private set; }
        public string? fechaConcluido { get; private set; }
        public ICollection<TripulacionVueloReadModel>? DetalleTripulacion { get; set; }


    }
}
