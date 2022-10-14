using Aerolinea.Vuelos.Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aerolinea.Vuelos.Infrastructure.EF.Config.ReadConfig {
    public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel> {
        public void Configure(EntityTypeBuilder<VueloReadModel> builder) {
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


            builder.Property(x => x.precio)
              .HasColumnName("precio")
              .HasColumnType("decimal")
              .HasPrecision(12, 2);

            builder.Property(x => x.fecha)
              .HasColumnName("fecha")
              .HasColumnType("DateTime");


            builder.Property(x => x.codRuta)
                 .HasColumnName("codRuta");



            builder.Property(x => x.codAeronave)
           .HasColumnName("codAeronave");

            builder.Property(x => x.activo)
          .HasColumnName("activo");

            builder.Property(x => x.stockAsientos)
         .HasColumnName("stockAsientos");

            builder.Property(x => x.codGrupoTripulacion)
            .HasColumnName("codGrupoTripulacion");


            builder.Property(x => x.horaConcluido)
          .HasColumnName("horaConcluido")
           .HasMaxLength(20);


            builder.Property(x => x.fechaConcluido)
                 .HasColumnName("fechaConcluido")
                  .HasMaxLength(20);


            builder.Ignore("_domainEvents");

            //builder.HasMany(x => x.DetalleTripulacion)
            //  .WithOne(x => x.vuelo);


            // builder.HasMany(x => x.detallePlanillaVuelo)
            //.WithOne(x => x.vuelo);

        }





    }
}
