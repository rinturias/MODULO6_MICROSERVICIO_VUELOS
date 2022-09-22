using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class VueloConcluido : DomainEvent {
        public Vuelo vueloConcluido { get; private set; }
        public VueloConcluido(Vuelo vuelo, DateTime occuredOn) : base(occuredOn) {

            vueloConcluido = vuelo;

        }



    }
}