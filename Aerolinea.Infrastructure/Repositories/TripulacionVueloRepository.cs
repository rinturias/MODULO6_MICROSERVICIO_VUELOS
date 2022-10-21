using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await _tripulacion.AsNoTracking().Where(x => x.codGrupo == codGrupoTripulante && x.activo == 0).ToListAsync();

            return (ICollection<TripulacionVuelo>)result;
        }

        public async Task SaveDetalleAsync(ICollection<TripulacionVuelo> obj) {

            await _tripulacion.AddRangeAsync(obj);
        }

        public Task UpdateAsync(TripulacionVuelo obj) {
            _tripulacion.Update(obj);
            return Task.CompletedTask;
        }
        public Task UpdateBajaDetalleAsync(ICollection<TripulacionVuelo> obj) {

            _tripulacion.UpdateRange(obj);
            return Task.CompletedTask;
        }
    }
}
