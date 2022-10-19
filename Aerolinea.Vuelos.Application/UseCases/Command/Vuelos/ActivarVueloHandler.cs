using System;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class ActivarVueloHandler : IRequestHandler<ActivarVueloCommand, ResulService> {


        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public ActivarVueloHandler(IUnitOfWork unitOfWork, IVueloRepository vueloRepository) {
            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
        }

        public async Task<ResulService> Handle(ActivarVueloCommand request, CancellationToken cancellationToken) {

            try {
                int codMarcaAlta = 0;
                Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.Detalle.idVuelo);

                if (objVuelo != null) {

                    objVuelo.ActivaVuelo(objVuelo.Id, codMarcaAlta);
                    await _vueloRepository.UpdateAsync(objVuelo);
                }
                else {
                    return new ResulService { codError = "COD403", messaje = "No existe el vuelo" };
                }


                await _unitOfWork.Commit();

                return new ResulService { data = objVuelo.Id, messaje = "se activo el vuelo" };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR activar el vuelo" };

        }


    }
}

