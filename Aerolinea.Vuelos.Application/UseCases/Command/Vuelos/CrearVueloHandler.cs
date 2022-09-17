using System;
using System.Threading;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.Services;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Factories;
using Aerolinea.Vuelos.Domain.Interfaces;
using MediatR;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos {
    public class CrearVueloHandler : IRequestHandler<CrearVuelosCommand, ResulService> {

        public readonly IVueloServices _vueloServices;
        public readonly IVuelosFactory _vuelosFactory;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IVueloRepository _vueloRepository;
        public CrearVueloHandler(IVueloServices vueloServices, IVuelosFactory vuelosFactory, IUnitOfWork unitOfWork, IVueloRepository vueloRepository) {
            _vueloServices = vueloServices;
            _vuelosFactory = vuelosFactory;
            _unitOfWork = unitOfWork;
            _vueloRepository = vueloRepository;
        }

        public async Task<ResulService> Handle(CrearVuelosCommand request, CancellationToken cancellationToken) {

            try {


                Vuelo objVuelo = _vuelosFactory.Create(request.Detalle.horaSalida, request.Detalle.horaLLegada, request.Detalle.estado, request.Detalle.precio, request.Detalle.fecha,
                 request.Detalle.codRuta, request.Detalle.codAeronave, request.Detalle.activo, request.Detalle.StockAsientos);

                foreach (var item in request.Detalle.tripulaciones) {
                    objVuelo.AgregarItem(item.codTripulacion, item.codEmpleado, item.estado, item.activo);
                }

                objVuelo.ConsolidarEventVueloHabilitado();

                await _vueloRepository.CreateAsync(objVuelo);

                await _unitOfWork.Commit();

                return new ResulService { data = objVuelo.Id, messaje = "se creo correctamente el vuelo" };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return new ResulService { success = false, error = ex.Message, codError = "COD501", messaje = "ERROR crear al crear vuelo" };

            }


        }


    }
}
