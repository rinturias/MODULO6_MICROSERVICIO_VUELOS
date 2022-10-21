using System;
using Aerolinea.Vuelos.Application.Dto;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto {
    public class RequestConcludeFlightDTO_Test {

        [Fact]
        public void RequestConcludeFlightDTO_CheckPropertiesValid() {
            Guid codVuelo = Guid.NewGuid();
            string estado = "A";

            RequestConcludeFlightDTO requestConcludeFlightDTO = new();

            Assert.Equal(Guid.Empty, requestConcludeFlightDTO.CodVuelo);
            Assert.Null(requestConcludeFlightDTO.estado);



            requestConcludeFlightDTO.CodVuelo = codVuelo;
            requestConcludeFlightDTO.estado = estado;


            Assert.Equal(requestConcludeFlightDTO.CodVuelo, codVuelo);
            Assert.NotNull(estado);
        }
    }
}
