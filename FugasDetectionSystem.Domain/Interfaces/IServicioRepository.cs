using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetAllAsync();
        Task<Servicio> GetByIdAsync(int servicioId);
        Task AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(int servicioId);
    }
}
