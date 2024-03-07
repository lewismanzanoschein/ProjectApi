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
		public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsers()
		{
			return await _context.Usuarios.AsNoTracking().ToListAsync();
		}


		[HttpGet("{Id:int}")]
		public async Task<ActionResult<Usuarios?>> GetIdUser(int Id)
		{
			var response = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == Id);
	
			return response;
				
				
				}

		[HttpPost]
		public async Task<ActionResult<Usuarios>> CreateUser(Usuarios us)
		{
			_context.Usuarios.Add(us);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetIdUser), new { id = us.Id }, us);
		}

		[HttpPut("{Id:int}")]
		public async Task<ActionResult<Usuarios>> UpdateUsers(int Id, Usuarios us) {

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == Id);
            usuario.Nombre = us.Nombre;


		    _context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{Id:int}")]
		public async Task<ActionResult<Usuarios>> DeleteUsers(int Id)
		{
			var data = await _context.Usuarios.FindAsync(Id);
			if (data == null)
			{
				return BadRequest();
			}

			_context.Usuarios.Remove(data); 
			await _context.SaveChangesAsync();
			return NoContent();
		}

	}
}
