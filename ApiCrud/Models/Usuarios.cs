using System.ComponentModel.DataAnnotations;

namespace ApiRestUser.Models
{
	public class Usuarios
	{
        [Key]
		public int  Id { get; set; }

        [Required]
        public long Numero_Identificacion { get; set; }

        [Required]
        public  string Nombre { get; set; }

        [Required]
        public string  Apellidos { get; set; }

        [Required]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required]
        public int Telefono {  get; set; }
    }
}
