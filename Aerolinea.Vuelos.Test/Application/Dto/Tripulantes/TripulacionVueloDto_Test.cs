using System;
using System.Collections.Generic;
using Aerolinea.Vuelos.Application.Dto.Tripulantes;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.Dto.Tripulantes {
    public class TripulacionVueloDto_Test {

        [Fact]
        public void TripulacionDto_CheckPropertiesValid() {
            var objTripulacion = new TripulacionVueloDto();

            var detalletripulacionesTest = getDetalleTripulacion();
            var codVueloTest = Guid.NewGuid();
            var codGrupoTest = Guid.NewGuid();

            Assert.Equal(null, objTripulacion.IdGrupo);
            Assert.Equal(Guid.Empty, objTripulacion.vueloId);
            Assert.Null(objTripulacion.tripulacionVuelos);

            objTripulacion.IdGrupo = codVueloTest.ToString();
            objTripulacion.vueloId = codVueloTest;

            objTripulacion.tripulacionVuelos = detalletripulacionesTest;


            Assert.Equal(codVueloTest.ToString(), objTripulacion.IdGrupo);
            Assert.Equal(codVueloTest, objTripulacion.vueloId);
            Assert.NotNull(objTripulacion.tripulacionVuelos);



        }

        private List<TripulacionDto> getDetalleTripulacion() {
            return new List<TripulacionDto>()
            {
                new()
                {
                    codVuelo = Guid.NewGuid(),
                    codTripulacion = Guid.NewGuid(),
                    codEmpleado = Guid.NewGuid(),
                    estado = "A",
                    activo = 0,

                },
                new()
                {
                    codVuelo = Guid.NewGuid(),
                    codTripulacion = Guid.NewGuid(),
                    codEmpleado = Guid.NewGuid(),
                    estado = "A",
                    activo = 0,
                },
                new()
                {
                    codVuelo = Guid.NewGuid(),
                    codTripulacion = Guid.NewGuid(),
                    codEmpleado = Guid.NewGuid(),
                    estado = "A",
                    activo = 0,
                }
            };
        }
    }
}
