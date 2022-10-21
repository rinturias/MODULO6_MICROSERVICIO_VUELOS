using System;
using Aerolinea.Vuelos.Application.Dto;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto {
    public class RequestVueloReprogramadoDTO_Test {

        [Fact]
        public void RequestVueloReprogramadoDTO_CheckPropertiesValid() {

            RequestVueloReprogramadoDTO objRequestVuelo = new RequestVueloReprogramadoDTO();
            DateTime horaSalidaTest = new DateTime();
            DateTime horaLLegadaTest = new DateTime();
            DateTime fechaTest = new DateTime();
            Guid codAeronaveTest = Guid.NewGuid();
            Guid codVuelo = Guid.NewGuid();


            Assert.Equal(new DateTime(), objRequestVuelo.horaSalida);
            Assert.Equal(new DateTime(), objRequestVuelo.horaLLegada);
            Assert.Equal(Guid.Empty, objRequestVuelo.codAeronave);
            Assert.Equal(new DateTime(), objRequestVuelo.fecha);
            Assert.Equal(Guid.Empty, objRequestVuelo.idVuelo);


            objRequestVuelo.horaSalida = horaSalidaTest;
            objRequestVuelo.horaLLegada = horaLLegadaTest;
            objRequestVuelo.fecha = fechaTest;
            objRequestVuelo.codAeronave = codAeronaveTest;
            objRequestVuelo.idVuelo = codVuelo;



            Assert.Equal(horaSalidaTest, objRequestVuelo.horaSalida);
            Assert.Equal(horaLLegadaTest, objRequestVuelo.horaLLegada);
            Assert.Equal(fechaTest, objRequestVuelo.fecha);
            Assert.Equal(codAeronaveTest, objRequestVuelo.codAeronave);
            Assert.Equal(codVuelo, objRequestVuelo.idVuelo);
        }

    }
}
