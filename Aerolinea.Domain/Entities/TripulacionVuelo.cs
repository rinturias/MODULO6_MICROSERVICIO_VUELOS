using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Entities {
    public class TripulacionVuelo : Entity<Guid> {

        public Guid codTripulacion { get; private set; }
        public Guid codEmpleado { get; private set; }
        public string estado { get; private set; }
        public int activo { get; private set; }
        public string descripcion { get; private set; }
        public Guid vueloId { get; private set; }




        private readonly ICollection<TripulacionVuelo> tripulacionVuelos;

        public IReadOnlyCollection<TripulacionVuelo> DetalleTripilacionVuelos {
            get {
                return new ReadOnlyCollection<TripulacionVuelo>(tripulacionVuelos.ToList());
            }
        }


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
        public void AgregarItem(Guid codTripulacion, Guid codEmpleado, string estadoTri, int activoTri) {

            var detalleTripulacion = tripulacionVuelos.FirstOrDefault(x => x.codTripulacion == codTripulacion);
            if (detalleTripulacion is null) {
                detalleTripulacion = new TripulacionVuelo(codTripulacion, codEmpleado, estadoTri, activoTri, Id);
                tripulacionVuelos.Add(detalleTripulacion);
            }
            else {
                detalleTripulacion.ModificarTripulacionVuelo(estadoTri, activoTri);
            }

        }
        internal void ModificarTripulacionVuelo(string estado, int activo) {

            this.estado = estado;
            this.activo = activo;
        }
    }
}
