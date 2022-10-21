using System;
using Aerolinea.Vuelos.Application.Dto;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto {
    public class SearchFlightDTO_Test {

        [Fact]
        public void SearchFlightDTO_CheckPropertiesValid() {
            var codVueloTest = Guid.NewGuid();


            var objDto = new SearchFlightDTO();

            Assert.Equal(Guid.Empty, objDto.IdVuelo);

            objDto.IdVuelo = codVueloTest;

            Assert.Equal(codVueloTest, objDto.IdVuelo);
        }
    }
}
