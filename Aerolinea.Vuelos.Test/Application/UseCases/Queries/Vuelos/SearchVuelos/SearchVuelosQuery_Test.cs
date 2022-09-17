using System;
using Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Queries.Vuelos.SearchVuelos {
    public class SearchVuelosQuery_Test {

        [Fact]
        public void IsRequest_Valid() {
            var detalle = MockFactory.GetSearchVuelo();
            var command = new SearchVuelosQuery();
            command.SearchVuelosDTO = detalle;
            Assert.NotNull(command.SearchVuelosDTO);
            // Assert.NotNull($"{command.Detalle} no es valido el dto request");
        }

        [Fact]
        public void TestConstructor_IsPrivate() {
            var command = (SearchVuelosQuery)Activator.CreateInstance(typeof(SearchVuelosQuery), true);
            Assert.Null(command.SearchVuelosDTO);
        }
    }
}
