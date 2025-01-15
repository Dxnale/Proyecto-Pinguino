using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Usuarios
    {
        [Key]
        public int CredencialVendedor { get; set; }

        [Required]
        public string Clave { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        [Required]
        [MaxLength(100)] 
        public string Correo { get; set; }

        [Required]
        public string TipoUsuario { get; set; }

        

        public ICollection<Venta> Ventas { get; set; }
    }
}
