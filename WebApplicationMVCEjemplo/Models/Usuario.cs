using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCEjemplo.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Telefono obligatorio")] 
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Email obligatorio")] 
        public string Email { get; set; }

    }
}
