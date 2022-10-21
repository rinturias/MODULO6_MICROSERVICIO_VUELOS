using System;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Tripulantes {
    public class CrearTripulanteHandler : IRequestHandler<CrearTripulanteCommand, ResulService> {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public readonly ITripulacionVueloRepository _tripulacionVuelo;
        public CrearTripulanteHandler(IUnitOfWork unitOfWork, IVueloRepository vueloRepository, ITripulacionVueloRepository tripulacionVuelo) {

            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
            _tripulacionVuelo = tripulacionVuelo;
        }



        public async Task<ResulService> Handle(CrearTripulanteCommand request, CancellationToken cancellationToken) {
            try {

                //DEBERIA ESTAR FACTORY
                TripulacionVuelo ObjTripulante = new(request.Detalle.vueloId, request.Detalle.IdGrupo);

                foreach (var item in request.Detalle.tripulacionVuelos) {
                    ObjTripulante.AgregarItem(item.codTripulacion, item.codEmpleado, item.estado, item.activo, request.Detalle.vueloId, request.Detalle.IdGrupo);
                }

                ObjTripulante.ConsolidarTripulantes(request.Detalle.vueloId);

                await _tripulacionVuelo.SaveDetalleAsync(ObjTripulante._tripulacionVuelos);


                Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.Detalle.vueloId);

                if (objVuelo != null) {

                    objVuelo.ActualizarGrupoTripulanteVuelo(objVuelo.Id, request.Detalle.IdGrupo);
                    await _vueloRepository.UpdateAsync(objVuelo);
                }
                else {
                    return new ResulService { codError = "COD403", messaje = "No existe el vuelo" };
                }


                await _unitOfWork.Commit();

                return new ResulService { messaje = "tripulacion creado el vuelo" };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());

            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR  al cocluir vuelo" };


        }
    }
}



