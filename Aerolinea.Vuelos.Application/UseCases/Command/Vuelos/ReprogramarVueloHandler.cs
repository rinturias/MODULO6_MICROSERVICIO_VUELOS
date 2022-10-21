using System;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    internal class ReprogramarVueloHandler : IRequestHandler<ReprogramarVueloCommand, ResulService> {


        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public ReprogramarVueloHandler(IUnitOfWork unitOfWork, IVueloRepository vueloRepository) {
            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
        }

        public async Task<ResulService> Handle(ReprogramarVueloCommand request, CancellationToken cancellationToken) {

            try {

                Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.Detalle.idVuelo);

                if (objVuelo != null) {

                    objVuelo.ReprogramarVuelo(objVuelo.Id, request.Detalle.horaLLegada, request.Detalle.horaSalida, request.Detalle.fecha, request.Detalle.codAeronave);
                    await _vueloRepository.UpdateAsync(objVuelo);
                }
                else {
                    return new ResulService { codError = "COD403", messaje = "No existe el vuelo" };
                }


                await _unitOfWork.Commit();

                return new ResulService { data = objVuelo.Id, messaje = "se reprogramo el vuelo" };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return new ResulService { success = false, codError = "COD501", messaje = "ERROR reprogramar el vuelo" };

        }


    }
}