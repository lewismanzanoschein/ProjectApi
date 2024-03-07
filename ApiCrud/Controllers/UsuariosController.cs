using ApiRestUser.Data;
using ApiRestUser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Controllers
{
	[Route("api/usuarios")]
	[ApiController]
	public class UsuariosController : ControllerBase
	{
		private readonly AplicationDbContext _context;

        public UsuariosController(AplicationDbContext context)
        {
			_context = context;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Usuario>>> GetUsers()
		{
			return await _context.Usuarios.AsNoTracking().ToListAsync();
		}


		[HttpGet("{Id:int}")]
		public async Task<ActionResult<Usuario?>> GetIdUser(int Id)
		{
			var response = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == Id);
	
			return response;
				
				
				}

		[HttpPost]
		public async Task<ActionResult<Usuario>> CreateUser(Usuario us)
		{
			_context.Usuarios.Add(us);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetIdUser), new { id = us.Id }, us);
		}

		[HttpPut("{Id:int}")]
		public async Task<ActionResult<Usuario>> UpdateUsers(int Id, Usuario UpdateUser) {

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == Id);
            if (usuario == null)
            {
                return NotFound();
            }

			usuario.Nombre = UpdateUser.Nombre;
			usuario.Apellidos = UpdateUser.Apellidos;
			usuario.Fecha_Nacimiento = UpdateUser.Fecha_Nacimiento;
			usuario.Numero_Identificacion = UpdateUser.Numero_Identificacion;
			usuario.Telefono = UpdateUser.Telefono;

            await _context.SaveChangesAsync();
            return NoContent();
		}

		[HttpDelete("{Id:int}")]
		public async Task<ActionResult<Usuario>> DeleteUsers(int Id)
		{
			var user = await _context.Usuarios.FindAsync(Id);
			if (user == null)
			{
				return BadRequest();
			}

			_context.Usuarios.Remove(user); 
			await _context.SaveChangesAsync();
			return NoContent();
		}

	}
}
