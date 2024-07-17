namespace FugasDetectionSystem.Domain.Entities
{
    // Clase para representar los bloques horarios en cada día
    public class BloqueHorario(string inicio, string termino)
    {
        public string Inicio { get; set; } = inicio;
        public string Termino { get; set; } = termino;
    }
}
