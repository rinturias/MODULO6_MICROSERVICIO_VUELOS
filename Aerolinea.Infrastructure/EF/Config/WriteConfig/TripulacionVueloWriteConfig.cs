using Aerolinea.Vuelos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aerolinea.Vuelos.Infrastructure.EF.Config.WriteConfig {
    internal class TripulacionVueloWriteConfig : IEntityTypeConfiguration<TripulacionVuelo> {
        public void Configure(EntityTypeBuilder<TripulacionVuelo> builder) {
            builder.ToTable("TripulacionVuelo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.codTripulacion)
           .HasColumnName("codTripulacion");

            builder.Property(x => x.codEmpleado)
           .HasColumnName("codEmpleado");

            builder.Property(x => x.estado)
           .HasColumnName("estado")
           .HasMaxLength(1);

            builder.Property(x => x.activo)
         .HasColumnName("activo");

            builder.Property(x => x.descripcion)
           .HasColumnName("descripcion")
           .HasMaxLength(300);

            builder.Property(x => x.codGrupo)
           .HasColumnName("codGrupo");




            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.tripulacionVuelos);

            //builder.Ignore(x => x._tripulacionVuelos);
            // builder.Property(x => x.vueloId)
            //.HasColumnName("vueloId");




        }
    }
}
