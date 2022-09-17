using System;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace AAerolinea.Vuelos.Domain.Interfaces {
    public interface IVueloRepository : InterfaceGeneric<Vuelo, Guid> {
        Task UpdateAsync(Vuelo obj);

        //Task RemoveAsync(Vuelo obj);
    }
}
