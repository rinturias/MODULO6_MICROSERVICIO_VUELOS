using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Interfaces {
    public interface ITripulacionVueloRepository : InterfaceGeneric<TripulacionVuelo, Guid> {
        Task UpdateAsync(TripulacionVuelo obj);
        Task<ICollection<TripulacionVuelo>> ListTripulantes(String codGrupoTripulante);
        Task SaveDetalleAsync(ICollection<TripulacionVuelo> obj);
        Task UpdateBajaDetalleAsync(ICollection<TripulacionVuelo> obj);
    }
}
