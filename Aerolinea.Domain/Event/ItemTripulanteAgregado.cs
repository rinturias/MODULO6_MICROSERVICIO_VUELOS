using System;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class ItemTripulanteAgregado : DomainEvent {

        public Guid codTripulacion { get; }
        public Guid codEmpleado { get; }
        public string estado { get; }
        public int activo { get; }
        public string descripcion { get; }
        public string codGrupo { get; }
        public Guid vueloId { get; }

        public ItemTripulanteAgregado(Guid codTripulacion, Guid codEmpleado, string estado, int activo, string descripcion, Guid vueloId, string codGrupo, DateTime occuredOn) : base(DateTime.Now) {
            this.codTripulacion = codTripulacion;
            this.codEmpleado = codEmpleado;
            this.estado = estado;
            this.activo = activo;
            this.descripcion = descripcion;
            this.vueloId = vueloId;
            this.codGrupo = codGrupo;
        }
    }
}
