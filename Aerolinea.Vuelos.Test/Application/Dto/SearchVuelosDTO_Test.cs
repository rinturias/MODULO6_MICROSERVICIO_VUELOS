using System;
using Aerolinea.Vuelos.Application.Dto;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto {
    public class SearchVuelosDTO_Test {

        [Fact]
        public void TripulacionDto_CheckPropertiesValid() {
            Guid CodVuelo = Guid.NewGuid();
            DateTime FecInicial = new DateTime();
            DateTime FecFinal = new DateTime();


            SearchVuelosDTO searchVuelosDTO = new();

            Assert.Equal(new DateTime(), searchVuelosDTO.FecInicial);
            Assert.Equal(new DateTime(), searchVuelosDTO.FecFinal);
            Assert.Equal(Guid.Empty, searchVuelosDTO.CodVuelo);



            searchVuelosDTO.CodVuelo = CodVuelo;
            searchVuelosDTO.FecInicial = FecInicial;
            searchVuelosDTO.FecFinal = FecFinal;


            Assert.Equal(CodVuelo, searchVuelosDTO.CodVuelo);
            Assert.Equal(FecInicial, searchVuelosDTO.FecInicial);
            Assert.Equal(FecFinal, searchVuelosDTO.FecFinal);
        }
    }
}
