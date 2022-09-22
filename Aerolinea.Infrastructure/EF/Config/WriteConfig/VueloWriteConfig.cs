using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aerolinea.Vuelos.Infrastructure.EF.Config.WriteConfig {
    public class VueloWriteConfig : IEntityTypeConfiguration<Vuelo> {
        public void Configure(EntityTypeBuilder<Vuelo> builder) {
            builder.ToTable("Vuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.horaSalida)
             .HasColumnName("horaSalida")
             .HasColumnType("DateTime");


            builder.Property(x => x.horaLLegada)
            .HasColumnName("horaLLegada")
            .HasColumnType("DateTime");



            builder.Property(x => x.estado)
                     .HasColumnName("estado")
                     .HasMaxLength(1);


            var precioConverter = new ValueConverter<PrecioValue, decimal>(
             precioValue => precioValue.Value,
             precio => new PrecioValue(precio)
            );

            builder.Property(x => x.precio)
              .HasConversion(precioConverter)
              .HasColumnName("precio")
              .HasColumnType("decimal")
              .HasPrecision(12, 2);



            /*    var fechaConverter = new ValueConverter<DateValueObject, DateTime>(
                 fechaValue => fechaValue.Value,
                 fecha => new DateValueObject(fecha)
                );
                */
            builder.Property(x => x.fecha)
            // .HasConversion(fechaConverter)
              .HasColumnName("fecha")
              .HasColumnType("DateTime");


            builder.Property(x => x.horaConcluido)
                 .HasColumnName("horaConcluido")
                  .HasMaxLength(20);


            builder.Property(x => x.fechaConcluido)
                 .HasColumnName("fechaConcluido")
                  .HasMaxLength(20);


            builder.Property(x => x.codRuta)
                 .HasColumnName("codRuta");


            builder.Property(x => x.codAeronave)
           .HasColumnName("codAeronave");

            builder.Property(x => x.activo)
          .HasColumnName("activo");

            var stockConverter = new ValueConverter<CantidadValue, int>(
            cantidadValue => cantidadValue.Value,
            cantidad => new CantidadValue(cantidad)
           );

            builder.Property(x => x.stockAsientos)
                .HasConversion(stockConverter)
               .HasColumnName("stockAsientos");


            builder.Property(x => x.codGrupoTripulacion)
               .HasColumnName("codGrupoTripulacion");

            //builder.HasMany(typeof(TripulacionVuelo), "tripulacionVuelos");



            // builder.HasMany(x => x.detallePlanillaVuelo)
            //.WithOne(x => x.vuelo);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            //builder.Ignore(x => x.DetalleTripilacionVuelos);
            // builder.Ignore("VueloId1");

        }
    }
}
