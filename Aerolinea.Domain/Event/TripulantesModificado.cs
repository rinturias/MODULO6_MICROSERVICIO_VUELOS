using System;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class TripulantesModificado : DomainEvent {


        public TripulacionVuelo tripulantes { get; private set; }

        public TripulantesModificado(TripulacionVuelo tripulanteAsignado, DateTime occuredOn) : base(occuredOn) {
            tripulantes = tripulanteAsignado;

        }

    }
}
