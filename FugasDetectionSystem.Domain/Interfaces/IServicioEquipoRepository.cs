using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IServicioEquipoRepository
    {
        Task<IEnumerable<ServicioEquipo>> GetAllAsync();
        Task<ServicioEquipo> GetByIdAsync(int servicioId, int equipoId);
        Task AddAsync(ServicioEquipo servicioEquipo);
        Task UpdateAsync(ServicioEquipo servicioEquipo);
        Task DeleteAsync(int servicioId, int equipoId);
    }
}
