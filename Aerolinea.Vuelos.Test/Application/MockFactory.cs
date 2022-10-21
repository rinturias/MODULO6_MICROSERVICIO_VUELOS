using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Entidades;
using Sharedkernel.IntegrationEvents;

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

        public static RequestConcludeFlightDTO GetRequestConcluderFligh() {
            return new RequestConcludeFlightDTO() {
                estado = "C",
                CodVuelo = Guid.NewGuid(),

            };
        }

        public static RequestVueloActivadoDTO GetRequestVueloActivado() {
            return new RequestVueloActivadoDTO() {
                idVuelo = Guid.NewGuid(),

            };
        }
        public static VueloDeleteDto GetVueloDeleteDto() {
            return new VueloDeleteDto() {
                idVuelo = Guid.NewGuid(),

            };
        }
        public static RequestVueloReprogramadoDTO GetRequestVueloReprogramadoDTO() {
            return new RequestVueloReprogramadoDTO() {
                idVuelo = Guid.NewGuid(),
                fecha = DateTime.Now,
                horaLLegada = DateTime.Now,
                horaSalida = DateTime.Now,
                codAeronave = Guid.NewGuid(),


            };
        }

        #region"DOMAIN EVENT"
        public static Vuelo GetVueloEvent() {
            DateTime v_horaSalida = DateTime.Now;
            DateTime v_horallegada = DateTime.Now;
            string v_estado = "A";
            int precio = 50;
            Guid codRuta = Guid.NewGuid();
            Guid codAeronave = Guid.NewGuid();
            DateTime fecha = DateTime.Now;
            int activo = 0;
            int stockAsientos = 100;

            return new Vuelo(v_horaSalida, v_horallegada, v_estado, precio, fecha, codRuta, codAeronave, activo, stockAsientos);
        }


        public static TripulacionCreado GetTripulanteCreadoEventConsumer() {


            ICollection<Tripulacion> collectionTripulacion = new Collection<Tripulacion>();
            Tripulacion objTripulacion = new Tripulacion() {
                vueloId = Guid.NewGuid(),
                codTripulacion = Guid.NewGuid(),
                codEmpleado = Guid.NewGuid(),
                estado = "A",
                activo = 0
            };
            collectionTripulacion.Add(objTripulacion);
            Tripulacion objTripulacion1 = new Tripulacion() {
                vueloId = Guid.NewGuid(),
                codTripulacion = Guid.NewGuid(),
                codEmpleado = Guid.NewGuid(),
                estado = "A",
                activo = 0
            };
            collectionTripulacion.Add(objTripulacion1);
            Tripulacion objTripulacion2 = new Tripulacion() {
                vueloId = Guid.NewGuid(),
                codTripulacion = Guid.NewGuid(),
                codEmpleado = Guid.NewGuid(),
                estado = "A",
                activo = 0
            };
            collectionTripulacion.Add(objTripulacion2);

            Guid vueloId = Guid.NewGuid();
            string codGrupo = Guid.NewGuid().ToString();
            return new TripulacionCreado() {
                IdGrupo = codGrupo,
                vueloId = vueloId,
                tripulacionVuelos = collectionTripulacion
            };
        }
        public static TripulacionModificado GetTripulanteModificadoEventConsumer() {


            ICollection<Tripulacion> collectionTripulacion = new Collection<Tripulacion>();
            Tripulacion objTripulacion = new Tripulacion() {
                vueloId = Guid.NewGuid(),
                codTripulacion = Guid.NewGuid(),
                codEmpleado = Guid.NewGuid(),
                estado = "A",
                activo = 0
            };
            collectionTripulacion.Add(objTripulacion);
            Tripulacion objTripulacion1 = new Tripulacion() {
                vueloId = Guid.NewGuid(),
                codTripulacion = Guid.NewGuid(),
                codEmpleado = Guid.NewGuid(),
                estado = "A",
                activo = 0
            };
            collectionTripulacion.Add(objTripulacion1);
            Tripulacion objTripulacion2 = new Tripulacion() {
                vueloId = Guid.NewGuid(),
                codTripulacion = Guid.NewGuid(),
                codEmpleado = Guid.NewGuid(),
                estado = "A",
                activo = 0
            };
            collectionTripulacion.Add(objTripulacion2);

            Guid vueloId = Guid.NewGuid();
            string codGrupo = Guid.NewGuid().ToString();
            return new TripulacionModificado() {
                IdGrupo = codGrupo,
                vueloId = vueloId,
                tripulacionVuelos = collectionTripulacion
            };
        }
        #endregion

        #region "SHAREKERNEL"  
        public async static Task<VueloReprogramado> GetVueloReprogrmadoShareKernel() {
            Guid codAeronave = Guid.NewGuid();
            DateTime fecha = DateTime.Now;
            Guid vueloId = Guid.NewGuid();
            DateTime v_horaSalida = DateTime.Now;
            DateTime v_horallegada = DateTime.Now;

            return new VueloReprogramado() {
                codAeronave = codAeronave,
                fecha = fecha.ToString(),
                vueloId = vueloId,
                horaSalida = v_horaSalida,
                horaLlegada = v_horallegada
            };
        }
        public static VueloReprogramado GetVueloReprogrmadoShareKernelEvent() {
            Guid codAeronave = Guid.NewGuid();
            DateTime fecha = DateTime.Now;
            Guid vueloId = Guid.NewGuid();
            DateTime v_horaSalida = DateTime.Now;
            DateTime v_horallegada = DateTime.Now;

            return new VueloReprogramado() {
                codAeronave = codAeronave,
                fecha = fecha.ToString(),
                vueloId = vueloId,
                horaSalida = v_horaSalida,
                horaLlegada = v_horallegada
            };
        }
        #endregion
    }
}
