namespace CalidadAireAPI.Models
{
    // Aca guardamos las alertas que se disparan según los niveles de la OMS
    public class AlertaAire
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public string Nivel { get; set; } = string.Empty; // Leve, Moderada, etc.
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; } = DateTime.Now;

        public SensorCalidadAire? Sensor { get; set; }
    }
}