using System;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto.Tripulantes {
    public class TripulacionDto_Test {

        [Fact]
        public void TripulacionDto_CheckPropertiesValid() {
            var codVueloTest = Guid.NewGuid();
            var codTripulacionTest = Guid.NewGuid();
            var codEmpleadoTest = Guid.NewGuid();
            var estadoTest = "A";
            var activoTest = 0;


            var objVuelo = new TripulacionDto();

            Assert.Equal(Guid.Empty, objVuelo.codVuelo);
            Assert.Equal(Guid.Empty, objVuelo.codTripulacion);
            Assert.Equal(Guid.Empty, objVuelo.codEmpleado);
            Assert.Null(objVuelo.estado);
            Assert.Equal(0, objVuelo.activo);


            objVuelo.codVuelo = codVueloTest;
            objVuelo.codTripulacion = codTripulacionTest;
            objVuelo.codEmpleado = codEmpleadoTest;
            objVuelo.estado = estadoTest;
            objVuelo.activo = activoTest;


            Assert.Equal(codVueloTest, objVuelo.codVuelo);
            Assert.Equal(codTripulacionTest, objVuelo.codTripulacion);
            Assert.Equal(codEmpleadoTest, objVuelo.codEmpleado);
            Assert.Equal(estadoTest, objVuelo.estado);
            Assert.Equal(activoTest, objVuelo.activo);

        }
    }
}
