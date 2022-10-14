using System;
using System.Threading.Tasks;
using AAerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Domain.Entities;
using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Aerolinea.Vuelos.Infrastructure.Repositories {
    public class VueloRepository : IVueloRepository {
        public readonly DbSet<Vuelo> _vuelos;

        public VueloRepository(WriteDbContext context) {
            _vuelos = context.vuelo;
        }

        public async Task CreateAsync(Vuelo obj) {
            await _vuelos.AddAsync(obj);
        }

        public async Task<Vuelo> FindByIdAsync(Guid id) {
            //return await _vuelos.Include("tripulacionVuelos")
            //          .SingleOrDefaultAsync(x => x.Id == id && x.activo == 0);
            return await _vuelos
                .SingleOrDefaultAsync(x => x.Id == id && x.activo == 0);
        }



        public Task UpdateAsync(Vuelo obj) {
            _vuelos.Update(obj);
            return Task.CompletedTask;
        }


    }
}
