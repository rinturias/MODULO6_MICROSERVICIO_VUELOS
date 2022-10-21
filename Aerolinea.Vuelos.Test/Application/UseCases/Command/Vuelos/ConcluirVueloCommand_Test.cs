using System;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Command.Vuelos {
    public class ConcluirVueloCommand_Test {

        [Fact]
        public void IsRequest_Valid() {
            var detalle = MockFactory.GetRequestConcluderFligh();
            var command = new ConcluirVueloCommand(detalle);

            Assert.NotNull(command.Detalle);

        }

        [Fact]
        public void TestConstructor_IsPrivate() {

            var command = (ConcluirVueloCommand)Activator.CreateInstance(typeof(ConcluirVueloCommand), true);

            Assert.Null(command.Detalle);
        }
    }
}
