using System;
using Aerolinea.Vuelos.Domain.Factories;
using Xunit;

namespace Aerolinea.Vuelos.Test.Domain.Factories {
    public class VuelosFactory_Test {
        [Fact]
        public void Create_Correctly() {
            DateTime horaSalida = DateTime.Now;
            DateTime horaLLegada = DateTime.Now;
            string estado = "A";
            decimal precio = new decimal(40.0);
            int StockAsientos = 10;
            DateTime fecha = new DateTime(2022, 01, 01);
            Guid codRuta = Guid.NewGuid();
            Guid codAeronave = Guid.NewGuid();
            int activo = 0;

            var factory = new VuelosFactory();
            var vuelo = factory.Create(horaSalida, horaLLegada, estado, precio, fecha, codRuta, codAeronave, activo, StockAsientos);

            Assert.NotNull(vuelo);
            Assert.Equal(StockAsientos, (decimal)vuelo.stockAsientos);
            Assert.Equal(precio, (decimal)vuelo.precio);
            Assert.Equal(codRuta, vuelo.codRuta);
            Assert.Equal(estado, vuelo.estado);
        }
    }
}
