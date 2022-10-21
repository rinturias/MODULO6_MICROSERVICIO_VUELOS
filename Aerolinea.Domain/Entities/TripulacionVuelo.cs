using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aerolinea.Vuelos.Domain.Event;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Entities {
    public class TripulacionVuelo : AggregateRoot<Guid> {

        public Guid codTripulacion { get; private set; }
        public Guid codEmpleado { get; private set; }
        public string estado { get; private set; }
        public int activo { get; private set; }
        public string descripcion { get; private set; }
        //public Guid? vueloId { get; private set; }
        public string codGrupo { get; private set; }



        public readonly ICollection<TripulacionVuelo> _tripulacionBajaVuelos;
        public readonly ICollection<TripulacionVuelo> _tripulacionAlta;
        public readonly ICollection<TripulacionVuelo> _tripulacionVuelos;

        public IReadOnlyCollection<TripulacionVuelo> tripulacionVuelos {
            get {
                return new ReadOnlyCollection<TripulacionVuelo>(_tripulacionVuelos.ToList());
            }
        }

        public TripulacionVuelo() {
            Id = Guid.NewGuid();
            this._tripulacionVuelos = new List<TripulacionVuelo>();
            this._tripulacionBajaVuelos = new List<TripulacionVuelo>();
            this._tripulacionAlta = new List<TripulacionVuelo>();
        }

        public TripulacionVuelo(Guid vueloId, string codGrupo) {
            Id = Guid.NewGuid();
            this._tripulacionVuelos = new List<TripulacionVuelo>();
            this._tripulacionBajaVuelos = new List<TripulacionVuelo>();
            this._tripulacionAlta = new List<TripulacionVuelo>();
            this.codGrupo = codGrupo;
        }

        internal TripulacionVuelo(Guid codTripulacion, Guid codEmpleado, string estado, int activo, Guid vueloId, string codGrupo) {
            Id = Guid.NewGuid();
            this.codTripulacion = codTripulacion;
            this.codEmpleado = codEmpleado;
            this.estado = estado;
            this.activo = activo;
            this.codGrupo = codGrupo;
        }

        internal TripulacionVuelo(Guid idTripulacion, Guid codTripulacion, Guid codEmpleado, string estado, int activo, Guid vueloId, string codGrupo) {
            this.Id = idTripulacion;
            this.codTripulacion = codTripulacion;
            this.codEmpleado = codEmpleado;
            this.estado = estado;
            this.activo = activo;
            this.descripcion = descripcion;
            this.codGrupo = codGrupo;
        }
        public void AgregarItem(Guid codTripulacion, Guid codEmpleado, string estadoTri, int activoTri, Guid vueloId, string codGrupo) {

            var detalleTripulaciones = _tripulacionVuelos.FirstOrDefault(x => x.codTripulacion == codTripulacion);
            if (detalleTripulaciones is null) {
                detalleTripulaciones = new TripulacionVuelo(codTripulacion, codEmpleado, estadoTri, activoTri, vueloId, codGrupo);
                _tripulacionVuelos.Add(detalleTripulaciones);
            }
            else {
                detalleTripulaciones.ModificarTripulacionVuelo(estadoTri, activoTri);
            }

        }


        public void ConsolidarTripulantes(Guid pCodVuelo) {
            var evento = new TripulanteAsignado(pCodVuelo, codGrupo, this._tripulacionVuelos, DateTime.Now);
            AddDomainEvent(evento);
        }
        internal void ModificarTripulacionVuelo(string estado, int activo) {

            this.estado = estado;
            this.activo = activo;
        }

        public void bajaTripulacion(Guid idTripulacion, Guid codTripulacion, Guid codEmpleado, string estadoTri, int activoTri, string descripcion, Guid vueloId, String codGrupo) {
            this.Id = idTripulacion;
            this.codTripulacion = codTripulacion;
            this.codEmpleado = codEmpleado;
            this.estado = estadoTri;
            this.activo = activoTri;
            this.descripcion = descripcion;
            this.codGrupo = codGrupo;
            var evento = new TripulacionVuelo(idTripulacion, codTripulacion, codEmpleado, estadoTri, activoTri, vueloId, codGrupo);
            _tripulacionBajaVuelos.Add(evento);

        }

        public void AltaTripulacion(Guid idTripulacion, Guid codTripulacion, Guid codEmpleado, string estadoTri, int activoTri, string descripcion, Guid vueloId, String codGrupo) {
            this.Id = idTripulacion;
            this.codTripulacion = codTripulacion;
            this.codEmpleado = codEmpleado;
            this.estado = estadoTri;
            this.activo = activoTri;
            this.descripcion = descripcion;
            this.codGrupo = codGrupo;
            var evento = new TripulacionVuelo(idTripulacion, codTripulacion, codEmpleado, estadoTri, activoTri, vueloId, codGrupo);
            _tripulacionAlta.Add(evento);

        }

    }
}
