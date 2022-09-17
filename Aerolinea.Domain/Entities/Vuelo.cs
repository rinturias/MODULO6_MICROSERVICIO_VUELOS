using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Domain.ValueObjects;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Entities {
    public class Vuelo : AggregateRoot<Guid> {

        public DateTime horaSalida { get; private set; }
        public DateTime horaLLegada { get; private set; }
        public string estado { get; private set; }
        public PrecioValue precio { get; private set; }
        public DateTime fecha { get; private set; }
        public Guid codRuta { get; private set; }
        public Guid codAeronave { get; private set; }
        public int activo { get; private set; }
        public CantidadValue stockAsientos { get; set; }



        private readonly ICollection<TripulacionVuelo> tripulacionVuelos;

        public IReadOnlyCollection<TripulacionVuelo> DetalleTripilacionVuelos {
            get {
                return new ReadOnlyCollection<TripulacionVuelo>(tripulacionVuelos.ToList());
            }
        }




        public Vuelo() {
            Id = Guid.NewGuid();
            this.tripulacionVuelos = new List<TripulacionVuelo>();
        }

        public Vuelo(DateTime horaSalida, DateTime horaLLegada, string estado, PrecioValue precio, DateTime fecha, Guid codRuta, Guid codAeronave, int activo, CantidadValue StockAsientos) {
            Id = Guid.NewGuid();
            this.tripulacionVuelos = new List<TripulacionVuelo>();

            this.estado = estado;
            this.precio = precio;

            this.horaSalida = DateTime.UtcNow;
            this.horaLLegada = DateTime.UtcNow;
            this.fecha = DateTime.UtcNow;

            this.codRuta = codRuta;
            this.codAeronave = codAeronave;
            this.activo = activo;
            this.stockAsientos = StockAsientos;

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


            //AddDomainEvent(new VueloHabilitado(this, DateTime.Now));

        }



        public void ConsolidarEventVueloHabilitado() {
            var evento = new VueloHabilitado(this, DateTime.Now);
            AddDomainEvent(evento);
        }

        public void EliminarVuelo(Guid codVuelo, int pActivo) {
            var evento = new VueloEliminado(this);
            activo = pActivo;
            AddDomainEvent(evento);
        }

        public void CloncluirVuelo(Guid pCodVuelo, string pEstado) {
            var evento = new VueloConcluido(this);
            Id = pCodVuelo;
            estado = pEstado;
            AddDomainEvent(evento);
        }
    }
}
