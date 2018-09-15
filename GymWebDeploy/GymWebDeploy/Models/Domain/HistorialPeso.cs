namespace GymWebDeploy.Models.Domain
{
    public class HistorialPeso
    {
        public int id_historial { get; set; }
        public int id_socio { get; set; }
        public decimal prev_peso { get; set; }
        public decimal prev_alto { get; set; }
        public decimal prev_bajo { get; set; }
        public decimal prev_cadera { get; set; }
    }
}