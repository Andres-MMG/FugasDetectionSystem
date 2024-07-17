namespace FugasDetectionSystem.Domain.Entities
{
    // Clase para representar la disponibilidad, ajusta según tus necesidades
    public class DisponibilidadCalendario
    {
        public DisponibilidadCalendario(IEnumerable<DisponibilidadTecnico> disponibilidades)
        {
            foreach(var disponibilidad in disponibilidades)
            {
                var inicio = disponibilidad.HoraInicio.ToString();
                var termino = disponibilidad.HoraFin.ToString();
                switch (disponibilidad.DiaSemana)
                {
                    case 1: // Lunes
                        Lunes.Add(new BloqueHorario(inicio, termino));
                        break;
                    case 2: // Martes
                        Martes.Add(new BloqueHorario(inicio, termino));
                        break;
                    case 3: // Miercoles
                        Miercoles.Add(new BloqueHorario(inicio, termino));
                        break;
                    case 4: // Jueves
                        Jueves.Add(new BloqueHorario(inicio, termino));
                        break;
                    case 5: // Viernes
                        Viernes.Add(new BloqueHorario(inicio, termino));
                        break;
                    case 6: // Sabado
                        Sabado.Add(new BloqueHorario(inicio, termino));
                        break;
                    case 7: // Domingo
                        Domingo.Add(new BloqueHorario(inicio, termino));
                        break;
                }
            }
        }

        public List<BloqueHorario> Lunes { get; set; } = [];
        public List<BloqueHorario> Martes { get; set; } = [];
        public List<BloqueHorario> Miercoles { get; set; } = [];
        public List<BloqueHorario> Jueves { get; set; } = [];
        public List<BloqueHorario> Viernes { get; set; } = [];
        public List<BloqueHorario> Sabado { get; set; } = [];
        public List<BloqueHorario> Domingo { get; set; } = [];
    }
}
