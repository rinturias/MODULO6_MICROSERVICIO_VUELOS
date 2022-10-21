using System;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Command.Vuelos {
    public class ActivarVueloCommand_Test {

        [Fact]
        public void IsRequest_Valid() {
            var detalle = MockFactory.GetRequestVueloActivado();
            var command = new ActivarVueloCommand(detalle);

            Assert.NotNull(command.Detalle);

        }

        [Fact]
        public void TestConstructor_IsPrivate() {

            var command = (ActivarVueloCommand)Activator.CreateInstance(typeof(ActivarVueloCommand), true);

            Assert.Null(command.Detalle);
        }
    }
}
