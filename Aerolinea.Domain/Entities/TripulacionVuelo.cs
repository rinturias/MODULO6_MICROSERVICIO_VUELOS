using System;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Entities {
    public class TripulacionVuelo : Entity<Guid> {
        //  public long codVuelo { get; private set; }
        public Guid codTripulacion { get; private set; }
        public Guid codEmpleado { get; private set; }
        public string estado { get; private set; }
        public int activo { get; private set; }
        //public Guid vueloId { get; private set; }



        private TripulacionVuelo() {

        }

        internal TripulacionVuelo(Guid codTripulacion, Guid codEmpleado, string estado, int activo, Guid vueloId) {
            Id = Guid.NewGuid();
            this.codTripulacion = codTripulacion;
            this.codEmpleado = codEmpleado;
            this.estado = estado;
            this.activo = activo;
            //this.vueloId =vueloId;
        }

        internal void ModificarTripulacionVuelo(string estado, int activo) {

            this.estado = estado;
            this.activo = activo;
        }
    }
}
