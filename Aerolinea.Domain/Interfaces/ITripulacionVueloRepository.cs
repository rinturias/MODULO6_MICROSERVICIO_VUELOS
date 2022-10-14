using System;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Interfaces {
    public interface ITripulacionVueloRepository : InterfaceGeneric<TripulacionVuelo, Guid> {
        Task UpdateAsync(TripulacionVuelo obj);
    }
}
