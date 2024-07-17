using FugasDetectionSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Domain.Interfaces
{
    public interface IContactoRepository
    {
        Task<IEnumerable<Contacto>> GetAllAsync();
        Task<Contacto> GetByIdAsync(int contactoId);
        Task AddAsync(Contacto contacto);
        Task UpdateAsync(Contacto contacto);
        Task DeleteAsync(int contactoId);
    }


   
}
