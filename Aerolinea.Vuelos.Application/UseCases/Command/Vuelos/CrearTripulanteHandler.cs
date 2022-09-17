using System;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class CrearTripulanteHandler : IRequestHandler<CrearTripulanteCommand, ResulService> {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public CrearTripulanteHandler(IUnitOfWork unitOfWork, IVueloRepository vueloRepository) {

            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
        }



        public async Task<ResulService> Handle(CrearTripulanteCommand request, CancellationToken cancellationToken) {
            try {


                Console.Write("INTERACCION DE COLA" + request);

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



