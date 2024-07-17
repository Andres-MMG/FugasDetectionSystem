namespace FugasDetectionSystem.Domain.Entities
{
    public class Visita
    {
        public int VisitaID { get; set; }
        public int TecnicoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Direccion { get; set; }
    }
}
