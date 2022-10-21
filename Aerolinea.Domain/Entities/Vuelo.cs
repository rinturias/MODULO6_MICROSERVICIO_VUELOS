using System;
using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Domain.ValueObjects;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Entities {
    public class Vuelo : AggregateRoot<Guid> {

        public DateTime horaSalida { get; private set; }
        public DateTime horaLLegada { get; private set; }

        public string? horaConcluido { get; private set; }
        public string? fechaConcluido { get; private set; }
        public string estado { get; private set; }
        public PrecioValue precio { get; private set; }
        public DateTime fecha { get; private set; }
        public Guid codRuta { get; private set; }
        public Guid codAeronave { get; private set; }
        public int activo { get; private set; }
        public CantidadValue stockAsientos { get; set; }

        public string? codGrupoTripulacion { get; set; }




        public Vuelo() {
            Id = Guid.NewGuid();
        }

        public Vuelo(DateTime horaSalida, DateTime horaLLegada, string estado, PrecioValue precio, DateTime fecha, Guid codRuta, Guid codAeronave, int activo, CantidadValue StockAsientos) {
            Id = Guid.NewGuid();

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




        public void ConsolidarEventVueloHabilitado() {
            var evento = new VueloHabilitado(this, DateTime.Now);
            AddDomainEvent(evento);
        }

        public void EliminarVuelo(Guid codVuelo, int pActivo) {
            var evento = new VueloEliminado(this);
            activo = pActivo;
            AddDomainEvent(evento);
        }
        public void ActivaVuelo(Guid codVuelo, int pActivo) {
            var evento = new VueloEliminado(this);
            activo = pActivo;
            AddDomainEvent(evento);
        }
        public void ActualizarGrupoTripulanteVuelo(Guid codVuelo, string pCodGrupoTripulantes) {
            var evento = new VueloTripulantesAsignados(this, DateTime.Now);
            codGrupoTripulacion = pCodGrupoTripulantes;
            AddDomainEvent(evento);
        }
        public void CloncluirVuelo(Guid pCodVuelo, string pEstado) {
            var evento = new VueloConcluido(this, DateTime.Now);
            Id = pCodVuelo;
            estado = pEstado;
            AddDomainEvent(evento);
        }
        public void ReprogramarVuelo(Guid codVuelo, DateTime horaSalida, DateTime horaLLegada, DateTime fecha, Guid codAeronave) {
            var evento = new VueloReprogramado(this, DateTime.Now);
            this.Id = codVuelo;
            this.horaSalida = horaSalida;
            this.horaLLegada = horaLLegada;
            this.fecha = fecha;
            this.codAeronave = codAeronave;
            AddDomainEvent(evento);
        }

    }
}
