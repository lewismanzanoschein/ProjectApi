using System.ComponentModel.DataAnnotations;

namespace WebUsers.Models
{
	public class Usuario
	{
		[Key]
		public int  Id { get; set; }

        [Required(ErrorMessage = "La identificacion es requerido.")]
        [Range(1000000000, 9999999999, ErrorMessage = "El número de identificación debe tener exactamente 10 dígitos.")]
        public long Numero_Identificacion { get; set; }

        [Required(ErrorMessage = "La Nombre es requerido.")]
        public  string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        public string  Apellidos { get; set; }

        [Required]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido.")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "El número debe tener exactamente 7 dígitos.")]
        public int Telefono {  get; set; }
    }
}
