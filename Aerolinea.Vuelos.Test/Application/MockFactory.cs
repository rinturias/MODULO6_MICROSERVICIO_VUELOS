using System;
using Aerolinea.Vuelos.Application.Dto;

namespace Aerolinea.Vuelos.Test.Application {
    public class MockFactory {

        public static RequestVueloDto GetVuelo() {
            return new RequestVueloDto() {
                horaSalida = DateTime.Now,
                horaLLegada = DateTime.Now,
                estado = "A",
                precio = 20,
                StockAsientos = 10,
                fecha = DateTime.Now,
                codRuta = Guid.NewGuid(),
                codAeronave = Guid.NewGuid()
                //activo = 0,
                //tripulaciones = new List<TripulacionDto> { new TripulacionDto()
                //{
                //    codVuelo=Guid.NewGuid(),
                //    codTripulacion=Guid.NewGuid(),
                //    codEmpleado=Guid.NewGuid(),
                //    estado="A",
                //    activo=0
                //}

            };

        }


        public static SearchVuelosDTO GetSearchVuelo() {
            return new SearchVuelosDTO() {
                FecInicial = DateTime.Now,
                FecFinal = DateTime.Now,
                CodVuelo = Guid.NewGuid(),

            };
        }
    }
}
