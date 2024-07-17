namespace FugasDetectionSystem.Domain.Entities
{
    public class Pago
    {
        public int PagoID { get; set; }
        public int ServicioID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
