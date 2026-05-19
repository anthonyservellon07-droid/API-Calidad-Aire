namespace CalidadAireAPI.Models
{
    // Clase principal para registrar los sensores físicos - planta ......................
    public class SensorCalidadAire
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public string TipoGas { get; set; } = string.Empty;


        public bool Estado { get; set; } = true;

        // Navegación para el Entity Framework............................................
        public List<LecturaAire> Lecturas { get; set; } = new();
        public List<AlertaAire> Alertas { get; set; } = new();
    }
}
