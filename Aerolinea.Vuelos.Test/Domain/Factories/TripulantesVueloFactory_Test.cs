using System;
using Aerolinea.Vuelos.Domain.Factories;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Factories {
    public class TripulantesVueloFactory_Test {

        [Fact]
        public void Create_Correctly() {
            Guid codTripulacion = Guid.NewGuid();
            Guid codEmpleado = Guid.NewGuid();
            string v_estado = "A";
            int activo = 0;
            string descripcion = "TEXTO DE DESCRIPCION";
            Guid vueloId = Guid.NewGuid();
            string codGrupo = Guid.NewGuid().ToString();

            var factory = new TripulantesVueloFactory();
            var tripulante = factory.Create(codTripulacion, codEmpleado, v_estado, activo, vueloId, codGrupo);

            Assert.NotNull(tripulante);
            Assert.Equal(codTripulacion, tripulante.codTripulacion);
            Assert.Equal(codEmpleado, tripulante.codEmpleado);
            Assert.Equal(v_estado, tripulante.estado);
            Assert.Equal(activo, tripulante.activo);
            //Assert.Equal(vueloId, tripulante.Id);
            Assert.Equal(codGrupo, tripulante.codGrupo);
        }
    }
}
