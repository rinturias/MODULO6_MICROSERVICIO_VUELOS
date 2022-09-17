////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;
////using Aerolinea.Vuelos.Application.Dto;
////using Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos;
////using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
////using Aerolinea.Vuelos.Infrastructure.EF.ReadModel;
////using Aerolinea.Vuelos.Infrastructure.EF.UseCases.Queries.Vuelos;
////using Microsoft.EntityFrameworkCore;
////using Moq;
////using Xunit;

////namespace Aerolinea.Vuelos.Test.Infrastructure.UseCases.Queries.Vuelos
////{
////    public class SearchVueloHandler_Test
////    {
////        private readonly Mock< DbSet<VueloReadModel>> _vuelos;

////        private readonly Mock<ReadDbContext> _ReadDbContext;

////        private SearchVuelosDTO objSearchVuelosDto =new SearchVuelosDTO()
////        {
////         CodVuelo= Guid.Parse("AE18157C-17AA-4C7C-B39D-FE574B5B363B"),
////         FecInicial=DateTime.Now,
////        FecFinal=DateTime.Now,

////        };
////        public SearchVueloHandler_Test()
////        {


////            _vuelos=new Mock<DbSet<VueloReadModel>>();
////            _ReadDbContext =new Mock<ReadDbContext>();
////        }


////        [Fact]
////        public void CrearProductoHandler_HandleCorrectly()
////        {


////            //productoFactory.Setup(factory => factory.Create(nombreProductoTest, precioActualTest, stockActualTest))
////            //    .Returns(productoTest);

////            var objHandler = new SearchVueloHandler(
////                _ReadDbContext.Object
////            );
////            var objRequest = new SearchVuelosQuery( );
////            var tcs = new CancellationTokenSource(1000);
////            var result = objHandler.Handle(objRequest, tcs.Token);
////            Assert.IsType<Guid>(result.Result);



////        }
////    }
////}
