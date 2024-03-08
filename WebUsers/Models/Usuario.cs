using System.ComponentModel.DataAnnotations;

namespace WebUsers.Models
{
	public class Usuario
	{
		[Key]
		public int  Id { get; set; }

        [Required]
        [StringLength(10,
        ErrorMessage = "Maximo 10 digitos")]
        public long Numero_Identificacion { get; set; }

        [Required]
        [StringLength(20,
        ErrorMessage = "Maximo 20 caracteres ")]
        public  string Nombre { get; set; }

        [Required]
        [StringLength(30,
        ErrorMessage = "Maximo 20 caracteres ")]
        public string  Apellidos { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "La fecha debe tener 10 caracteres (dd/MM/yyyy).")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "longitud de telefono de 7 caracteres")]
        public int Telefono {  get; set; }
    }
}
