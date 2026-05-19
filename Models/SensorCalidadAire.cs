namespace CalidadAireAPI.Models
{
    // Clase principal para registrar los sensores físicos de la planta
    public class SensorCalidadAire
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public string TipoGas { get; set; } = string.Empty;

        // Lo ponemos en true por defecto para no batallar al crear nuevos
        public bool Estado { get; set; } = true;

        // Navegación para Entity Framework
        public List<LecturaAire> Lecturas { get; set; } = new();
        public List<AlertaAire> Alertas { get; set; } = new();
    }
}