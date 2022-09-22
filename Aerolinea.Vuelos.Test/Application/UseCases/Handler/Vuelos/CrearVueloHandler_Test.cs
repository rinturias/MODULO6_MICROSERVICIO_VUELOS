using System;
using System.Threading;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.Services;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Factories;
using Aerolinea.Vuelos.Domain.Interfaces;
using Moq;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Handler.Vuelos {
    public class CrearVueloHandler_Test {
        private readonly Mock<IVueloRepository> _vueloRepository;
        private readonly Mock<IVueloServices> _vueloServices;
        private readonly Mock<IVuelosFactory> _vuelosFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;



        private DateTime horaSalida = DateTime.Now;
        private DateTime horaLLegada = DateTime.Now;
        private string estado = "A";
        private decimal precio = new decimal(40.0);
        private int StockAsientos = 10;
        private DateTime fecha = new DateTime(2022, 01, 01);
        private Guid codRuta = Guid.NewGuid();
        private Guid codAeronave = Guid.NewGuid();
        private int activo = 0;



        private RequestVueloDto objVuelosTest = MockFactory.GetVuelo();


        private Vuelo _vueloTest;
        public CrearVueloHandler_Test() {
            _vueloRepository = new Mock<IVueloRepository>();
            _vueloServices = new Mock<IVueloServices>();

            _vuelosFactory = new Mock<IVuelosFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _vueloTest = new VuelosFactory().Create(horaSalida, horaLLegada, estado, precio, fecha, codRuta, codAeronave, activo, StockAsientos);


        }

        [Fact]
        public async void CrearVueloHandler_HandleSuccess() {


            //  _vuelosFactory.Setup(_vuelosFactory => _vuelosFactory.Create(horaSalida, horaLLegada, estado, precio, fecha, codDestino, codOrigen, codAeronave, activo, StockAsientos)).Returns(_vueloTest);

            var objHandler = new CrearVueloHandler(
               _vueloServices.Object,
               _vuelosFactory.Object,
               _unitOfWork.Object,
               _vueloRepository.Object
               );

            var objRequest = new CrearVuelosCommand(
                objVuelosTest
            );
            var tcs = new CancellationTokenSource(1000);

            ResulService result = await objHandler.Handle(objRequest, tcs.Token);

            //_vueloTest.AgregarItem(objVuelosTest.tripulaciones[0].codTripulacion, objVuelosTest.tripulaciones[0].codEmpleado, objVuelosTest.tripulaciones[0].estado, objVuelosTest.tripulaciones[0].activo);
            _vueloTest.ConsolidarEventVueloHabilitado();
            //_unitOfWork.Verify(mock => mock.Commit(), Times.Once);            

            Assert.IsType<ResulService>(result);


        }

    }
}
