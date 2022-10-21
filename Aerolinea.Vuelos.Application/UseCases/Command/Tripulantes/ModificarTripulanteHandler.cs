using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Tripulantes {
    internal class ModificarTripulanteHandler : IRequestHandler<ModificarTripulanteCommand, ResulService> {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public readonly ITripulacionVueloRepository _tripulacionVuelo;
        public ModificarTripulanteHandler(IUnitOfWork unitOfWork, IVueloRepository vueloRepository, ITripulacionVueloRepository tripulacionVuelo) {

            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
            _tripulacionVuelo = tripulacionVuelo;
        }



        public async Task<ResulService> Handle(ModificarTripulanteCommand request, CancellationToken cancellationToken) {
            try {

                TripulacionVuelo objTripuBaja = new TripulacionVuelo();
                var listTripulantesParaBaja = new Collection<TripulacionVuelo>();

                request.Detalle.IdGrupo = "a27b629c-0674-444d-9e22-8f5da373f100";

                var listTripulantes = await _tripulacionVuelo.ListTripulantes(request.Detalle.IdGrupo);
                if (listTripulantes != null) {


                    foreach (var item in request.Detalle.tripulacionVuelos) {

                        var existeTripulante = listTripulantes.FirstOrDefault(e => e.codTripulacion == item.codTripulacion);
                        if (existeTripulante != null) {

                            listTripulantesParaBaja.Add(existeTripulante);
                        }
                        else {

                            var usuarioAlta = request.Detalle.tripulacionVuelos.Where(x => x.codTripulacion == item.codTripulacion).ToList();
                            objTripuBaja.AgregarItem(usuarioAlta[0].codTripulacion, usuarioAlta[0].codEmpleado, usuarioAlta[0].estado, usuarioAlta[0].activo, request.Detalle.vueloId, request.Detalle.IdGrupo);
                            await _tripulacionVuelo.SaveDetalleAsync(objTripuBaja._tripulacionVuelos);
                        }

                    }

                    ICollection<TripulacionVuelo> diff = listTripulantes.Except(listTripulantesParaBaja).ToList();

                    foreach (var itemDif in diff) {

                        objTripuBaja.bajaTripulacion(itemDif.Id, itemDif.codEmpleado, itemDif.codTripulacion, "I", 9, itemDif.descripcion, request.Detalle.vueloId, request.Detalle.IdGrupo);

                    }
                    await _tripulacionVuelo.UpdateBajaDetalleAsync(objTripuBaja._tripulacionBajaVuelos);
                }

                else {
                    return new ResulService { codError = "COD403", messaje = "No existe grupo tripulante" };
                }


                await _unitOfWork.Commit();

                return new ResulService { messaje = "tripulacion modificado  del vuelo" };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());

            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR  al cocluir vuelo" };


        }
    }
}
