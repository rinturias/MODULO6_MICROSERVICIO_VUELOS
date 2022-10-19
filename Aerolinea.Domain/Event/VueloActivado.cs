using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class VueloActivado : DomainEvent {
        public Vuelo vueloActivado { get; private set; }
        public VueloActivado(Vuelo vuelo, DateTime occuredOn) : base(occuredOn) {

            vueloActivado = vuelo;

        }
    }
}
