using System;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Event;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Event {
    public class TripulantesModificado_Test {

        [Fact]
        public void IsRequest_Valid() {

            Guid codTripulacion = Guid.NewGuid();
            Guid codEmpleado = Guid.NewGuid();
            string v_estado = "A";
            int activo = 0;
            string descripcion = "TEXTO DE DESCRIPCION";
            Guid vueloId = Guid.NewGuid();
            string codGrupo = Guid.NewGuid().ToString();
            var objVueloTest = new TripulacionVuelo();

            var evento = new TripulantesModificado(objVueloTest, DateTime.Now);

            Assert.NotNull(evento);
            Assert.NotNull(evento.tripulantes);

        }
    }
}
