using System;
using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Test.Application;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Event {
    public class VueloHabilitado_Test {



        [Fact]
        public void IsRequest_Valid() {
            var objVueloTest = MockFactory.GetVueloEvent();
            var evento = new VueloHabilitado(objVueloTest, DateTime.Now);

            Assert.NotNull(evento);
            Assert.NotNull(evento.vueloHabilitado);

        }
    }
}
