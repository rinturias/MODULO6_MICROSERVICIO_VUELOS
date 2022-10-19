using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Aerolinea.Vuelos.Infrastructure.Repositories {
    public class TripulacionVueloRepository : ITripulacionVueloRepository {

        public readonly DbSet<TripulacionVuelo> _tripulacion;

        public TripulacionVueloRepository(WriteDbContext context) {
            _tripulacion = context.tripulacionVuelo;
        }
        public async Task CreateAsync(TripulacionVuelo obj) {
            await _tripulacion.AddAsync(obj);
        }

        public Task<TripulacionVuelo> FindByIdAsync(Guid id) {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TripulacionVuelo>> ListTripulantes(String codGrupoTripulante) {
            return (ICollection<TripulacionVuelo>)await _tripulacion
               .SingleOrDefaultAsync(x => x.codGrupo == codGrupoTripulante && x.activo == 0);
        }

        public Task UpdateAsync(TripulacionVuelo obj) {
            _tripulacion.Update(obj);
            return Task.CompletedTask;
        }
    }
}
