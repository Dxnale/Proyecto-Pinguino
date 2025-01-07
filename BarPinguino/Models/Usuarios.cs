namespace EVA2TI_BarPinguino.Models
{
    public class Usuarios
    {
        public int Credencial_vendedor { get; set; }
        public string clave { get; set; }
        public string Nombre { get; set; }
        public string TipoDeUsuario { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
