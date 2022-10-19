using System;
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



                var listTripulantes = await _tripulacionVuelo.ListTripulantes(request.Detalle.IdGrupo);
                if (listTripulantes.Count > 0) {

                    foreach (var item in listTripulantes) {

                    }


                }

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
