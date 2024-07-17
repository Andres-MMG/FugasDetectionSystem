namespace FugasDetectionSystem.Domain.Entities
{
    public class DisponibilidadTecnico
    {
        public int DisponibilidadID { get; set; }
        public int TecnicoID { get; set; }
        public byte DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
