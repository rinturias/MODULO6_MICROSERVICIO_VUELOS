using System;
using Aerolinea.Vuelos.Application.Dto;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto {
    public class RequestVueloActivadoDTO_Test {


        [Fact]
        public void RequestVueloActivadoDTO_CheckPropertiesValid() {
            Guid codVuelo = Guid.NewGuid();


            RequestVueloActivadoDTO requestVueloActivadoDTO = new();

            Assert.Equal(Guid.Empty, requestVueloActivadoDTO.idVuelo);


            requestVueloActivadoDTO.idVuelo = codVuelo;

            Assert.Equal(requestVueloActivadoDTO.idVuelo, codVuelo);

        }
    }
}
