using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Domain.Interfaces {
    public interface IUnitOfWork {
        Task Commit();
    }
}
