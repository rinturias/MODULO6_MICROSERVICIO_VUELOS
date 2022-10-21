using System;
using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Test.Application;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Event {
    public class VueloReprogramado_Test {

        [Fact]
        public void IsRequest_Valid() {
            var objVueloTest = MockFactory.GetVueloEvent();
            var evento = new VueloReprogramado(objVueloTest, DateTime.Now);

            Assert.NotNull(evento);
            Assert.NotNull(evento.vueloReprogramado);

        }
    }
}
