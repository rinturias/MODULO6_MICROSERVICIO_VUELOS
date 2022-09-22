using System;
using System.Collections.Generic;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class TripulanteAsignado : DomainEvent {

        public Guid idVuelo { get; }
        public ICollection<TripulacionVuelo> tripulacionVuelos { get; private set; }
        public TripulanteAsignado(Guid idVuelo, ICollection<TripulacionVuelo> tripulacionVuelos, DateTime occuredOn) : base(occuredOn) {

            this.idVuelo = idVuelo;
            this.tripulacionVuelos = tripulacionVuelos;

        }




    }
}
