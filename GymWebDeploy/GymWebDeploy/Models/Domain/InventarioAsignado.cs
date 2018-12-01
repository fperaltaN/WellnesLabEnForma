namespace GymWebDeploy.Models.Domain
{
    public class InventarioAsignado
    {
        public int Id_inventario { get; set; }
        public string catnombre { get; set; }
        public int num_control { get; set; }
        public int id_cat_inventario { get; set; }
        public int id_socio { get; set; }
        public string socioName { get; set; }
        public string nombre { get; set; }
    }
}