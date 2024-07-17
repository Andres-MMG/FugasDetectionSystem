namespace FugasDetectionSystem.Domain.Entities
{
    public class Interaccion
    {
        public int InteraccionID { get; set; }
        public int ClienteID { get; set; }
        public int CanalID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public int AtendidoPor { get; set; }
    }
}
