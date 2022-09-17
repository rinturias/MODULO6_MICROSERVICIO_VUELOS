using System;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class EliminarVueloHandler : IRequestHandler<EliminarVueloCommand, ResulService> {


        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public EliminarVueloHandler(IUnitOfWork unitOfWork, IVueloRepository vueloRepository) {
            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
        }

        public async Task<ResulService> Handle(EliminarVueloCommand request, CancellationToken cancellationToken) {

            try {
                int codMarcaBaja = 9;
                Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.Detalle.codVuelo);

                if (objVuelo != null) {

                    objVuelo.EliminarVuelo(objVuelo.Id, codMarcaBaja);
                    await _vueloRepository.UpdateAsync(objVuelo);
                }
                else {
                    return new ResulService { codError = "COD403", messaje = "No existe el vuelo" };
                }


                await _unitOfWork.Commit();

                return new ResulService { data = objVuelo.Id, messaje = "se elimino el vuelo" };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());

            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR crear al crear vuelo" };

        }


    }
}

