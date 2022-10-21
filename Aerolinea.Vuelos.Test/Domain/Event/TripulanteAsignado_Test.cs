using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Event;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Event {
    public class TripulanteAsignado_Test {

        [Fact]
        public void IsRequest_Valid() {


            Guid vueloId = Guid.NewGuid();
            string codGrupo = Guid.NewGuid().ToString();
            var objVueloTest = new TripulacionVuelo();
            ICollection<TripulacionVuelo> listTripulantes = new Collection<TripulacionVuelo>();
            listTripulantes.Add(objVueloTest);
            var evento = new TripulanteAsignado(vueloId, codGrupo, listTripulantes, DateTime.Now);

            Assert.NotNull(evento);
            Assert.Equal(1, evento.tripulacionVuelos.Count);
            Assert.Equal(codGrupo, evento.codGrupo);
            Assert.Equal(vueloId, evento.idVuelo);
        }
    }
}
