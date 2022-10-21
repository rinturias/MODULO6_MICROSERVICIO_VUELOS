using System;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Command.Vuelos {
    public class EliminarVueloCommand_Test {

        [Fact]
        public void IsRequest_Valid() {
            var detalle = MockFactory.GetVueloDeleteDto();
            var command = new EliminarVueloCommand(detalle);

            Assert.NotNull(command.Detalle);

        }

        [Fact]
        public void TestConstructor_IsPrivate() {

            var command = (EliminarVueloCommand)Activator.CreateInstance(typeof(EliminarVueloCommand), true);

            Assert.Null(command.Detalle);
        }
    }

}
