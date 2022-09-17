using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class VueloEliminado : DomainEvent {
        public Vuelo vueloEliminado { get; private set; }
        public VueloEliminado(Vuelo vuelo) : base(DateTime.Now) {

            vueloEliminado = vuelo;


        }



    }
}
