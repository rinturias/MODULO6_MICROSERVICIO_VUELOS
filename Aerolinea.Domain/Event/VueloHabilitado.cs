using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class VueloHabilitado : DomainEvent {
        // public Guid vueloId { get; }
        public VueloHabilitado(Vuelo vuelo, DateTime occuredOn) : base(occuredOn) {

            vueloHabilitado = vuelo;

        }

        public Vuelo vueloHabilitado { get; set; }

    }
}

