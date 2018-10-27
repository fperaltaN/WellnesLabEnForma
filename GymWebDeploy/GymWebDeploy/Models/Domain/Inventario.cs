namespace GymWebDeploy.Models.Domain
{
    public class Inventario
    {
        public int Id_inventario { get; set; }
        public int Id_cat_inventario { get; set; }
        public int Num_control { get; set; }
        public string nombre { get; set; }
        public int Id_socio { get; set; }
        public bool Activo { get; set; }
    }
}