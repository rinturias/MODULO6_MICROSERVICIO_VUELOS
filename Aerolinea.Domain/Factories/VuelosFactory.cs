using System;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.ValueObjects;

namespace Aerolinea.Vuelos.Domain.Factories {
    public class VuelosFactory : IVuelosFactory {

        public VuelosFactory() {

        }


        public Vuelo Create(DateTime horaSalida, DateTime horaLLegada, string estado, PrecioValue precio, DateTime fecha, Guid codRuta, Guid codAeronave, int activo, CantidadValue StockAsientos) {
            return new Vuelo(horaSalida, horaLLegada, estado, precio, fecha, codRuta, codAeronave, activo, StockAsientos);
        }
    }
}
