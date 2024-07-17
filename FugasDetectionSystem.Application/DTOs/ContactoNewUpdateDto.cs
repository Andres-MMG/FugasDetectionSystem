using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FugasDetectionSystem.Application.DTOs
{
    public class ContactoNewUpdateDto
    {
        public string OrigenId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string CoordenadasMaps { get; set; }
        public DateTime FechaTentativaVisita { get; set; } = DateTime.Now;
        public string HorarioTentativoId { get; set; }
    }
}
