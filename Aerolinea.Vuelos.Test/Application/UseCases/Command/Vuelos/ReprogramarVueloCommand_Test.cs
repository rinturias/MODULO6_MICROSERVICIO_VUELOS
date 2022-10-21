using System;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Command.Vuelos {
    public class ReprogramarVueloCommand_Test {

        [Fact]
        public void IsRequest_Valid() {
            var detalle = MockFactory.GetRequestVueloReprogramadoDTO();
            var command = new ReprogramarVueloCommand(detalle);

            Assert.NotNull(command.Detalle);

        }

        [Fact]
        public void TestConstructor_IsPrivate() {

            var command = (ReprogramarVueloCommand)Activator.CreateInstance(typeof(ReprogramarVueloCommand), true);

            Assert.Null(command.Detalle);
        }
    }

}