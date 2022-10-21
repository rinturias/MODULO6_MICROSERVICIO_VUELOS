using System;
using Aerolinea.Vuelos.Application.Dto;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto {
    public class ResulService_DTO {


        [Fact]
        public void ResulService_CheckPropertiesValid() {
            var error = "Error";
            var codError = "COD400";
            var data = new ResulService_DTO();
            var mensaje = "Prueba";
            var success = true;


            ResulService ResulService = new();

            Assert.Equal(String.Empty, ResulService.error);
            Assert.Equal("COD200", ResulService.codError);
            Assert.Equal(null, ResulService.data);
            Assert.Equal(null, ResulService.messaje);
            Assert.True(ResulService.success);



            ResulService.error = error;
            ResulService.codError = codError;
            ResulService.data = data;
            ResulService.messaje = mensaje;
            ResulService.success = success;

            Assert.Equal(error, ResulService.error);
            Assert.Equal(codError, ResulService.codError);
            Assert.NotNull(data);
            Assert.Equal(mensaje, ResulService.messaje);
            Assert.Equal(success, ResulService.success);
        }
    }
}
