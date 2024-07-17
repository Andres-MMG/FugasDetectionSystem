using System.Collections.Generic;
using System.Threading.Tasks;
using FugasDetectionSystem.Domain.Entities;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<Pago> GetByIdAsync(int pagoId);
        Task AddAsync(Pago pago);
        Task UpdateAsync(Pago pago);
        Task DeleteAsync(int pagoId);
    }
}
