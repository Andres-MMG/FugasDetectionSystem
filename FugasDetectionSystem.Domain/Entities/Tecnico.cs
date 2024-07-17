namespace FugasDetectionSystem.Domain.Entities
{
    public class Tecnico
    {
        public int TecnicoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }
}
