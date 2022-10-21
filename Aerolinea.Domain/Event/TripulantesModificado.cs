using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class TripulantesModificado : DomainEvent {

        //public Guid codTripulacion { get; }
        //public Guid codEmpleado { get; }
        //public string estado { get; }
        //public int activo { get; }
        //public string descripcion { get; }
        //public string codGrupo { get; }
        //public Guid vueloId { get; }

        //public TripulantesModificado(Guid codTripulacion, Guid codEmpleado, string estado, int activo, string descripcion, Guid vueloId, string codGrupo, DateTime occuredOn) : base(occuredOn) {
        //    this.codTripulacion = codTripulacion;
        //    this.codEmpleado = codEmpleado;
        //    this.estado = estado;
        //    this.activo = activo;
        //    this.descripcion = descripcion;
        //    this.vueloId = vueloId;
        //    this.codGrupo = codGrupo;
        //}
        public TripulacionVuelo tripulantes { get; private set; }
        public TripulantesModificado(TripulacionVuelo tripulanteAsignado, DateTime occuredOn) : base(occuredOn) {
            tripulantes = tripulanteAsignado;

        }

    }
}
