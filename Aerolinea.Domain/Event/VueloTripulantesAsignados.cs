using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class VueloTripulantesAsignados : DomainEvent {

        public VueloTripulantesAsignados(Vuelo vuelo, DateTime occuredOn) : base(occuredOn) {

            vueloTripulanteAsignado = vuelo;

        }

        public Vuelo vueloTripulanteAsignado { get; set; }
    }
}
