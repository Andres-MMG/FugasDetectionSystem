namespace FugasDetectionSystem.Domain.Entities
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        public string OrigenId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string CoordenadasMaps { get; set; }
        public DateTime FechaTentativaVisita { get; set; }
        public string HorarioTentativoId { get; set; }
    }
}
