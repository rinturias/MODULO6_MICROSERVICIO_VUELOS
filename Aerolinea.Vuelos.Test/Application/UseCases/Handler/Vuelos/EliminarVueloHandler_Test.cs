using System;
using System.Threading;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using Moq;
using Xunit;

namespace Aerolinea.Vuelos.Test.Application.UseCases.Handler.Vuelos {
    public class EliminarVueloHandler_Test {
        private readonly Mock<IVueloRepository> _vueloRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;


        private Guid codVuelo = Guid.NewGuid();
        private DateTime horaSalida = DateTime.Now;
        private DateTime horaLLegada = DateTime.Now;
        private string estado = "A";
        private decimal precio = new decimal(40.0);
        private int StockAsientos = 10;
        private DateTime fecha = new DateTime(2022, 01, 01);
        private Guid codRuta = Guid.NewGuid();
        private Guid codAeronave = Guid.NewGuid();
        private int activo = 0;

        private VueloDeleteDto objVuelosDeleteDto = new() {
            idVuelo = Guid.Parse("D6065F05-533F-4C4A-81B4-09561258CD43")
        };
        private Vuelo _vueloTest;
        public EliminarVueloHandler_Test() {
            _vueloRepository = new Mock<IVueloRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _vueloTest = new Vuelo(horaSalida, horaLLegada, estado, precio, fecha, codRuta, codAeronave, activo, StockAsientos);
        }

        [Fact]
        public void ElimarVueloHandler_HandleSuccess() {


            int CodMarcaBaja = 9;




            _vueloRepository.Setup(_vuelosFactory => _vuelosFactory.FindByIdAsync(objVuelosDeleteDto.idVuelo)).ReturnsAsync(_vueloTest);


            var objHandler = new EliminarVueloHandler(
             _unitOfWork.Object,
             _vueloRepository.Object
             );


            var objRequest = new EliminarVueloCommand(
             objVuelosDeleteDto
          );

            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);




            _vueloTest.EliminarVuelo(_vueloTest.Id, CodMarcaBaja);
            _unitOfWork.Verify(mock => mock.Commit(), Times.Once);

            Assert.Equal(9, _vueloTest.activo);

        }

    }
}
