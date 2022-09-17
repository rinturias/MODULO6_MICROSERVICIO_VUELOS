using System;
using Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Queries.Vuelos.SearchVuelos {
    public class SearchListVuelosQuery_Test {


        [Fact]
        public void TestConstructor_IsPrivate() {
            var command = (SearchListVuelosQuery)Activator.CreateInstance(typeof(SearchListVuelosQuery), true);
            Assert.NotNull(command);
        }
    }
}
