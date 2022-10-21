using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Test.Application;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Event {
    public class VueloEliminado_Test {

        [Fact]
        public void IsRequest_Valid() {
            var objVueloTest = MockFactory.GetVueloEvent();
            var evento = new VueloEliminado(objVueloTest);

            Assert.NotNull(evento);
            Assert.NotNull(evento.vueloEliminado);

        }
    }
}
