using System.ComponentModel.DataAnnotations;

namespace IgrtecPrueba.Web.Models
{
    public class Aspirante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        public string CorreoElectronico { get; set; }

        [Phone(ErrorMessage = "El número telefónico no es válido.")]
        [Required(ErrorMessage = "El número telefónico es obligatorio.")]
        public string NumTelefonico { get; set; }
        [Required(ErrorMessage = "El lugar de nacimiento es obligatorio.")]
        public string LugarNacimiento { get; set; }
    }
}
