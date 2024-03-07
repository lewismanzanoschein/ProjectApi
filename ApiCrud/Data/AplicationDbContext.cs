using ApiRestUser.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestUser.Data
{
	public class AplicationDbContext : DbContext
	{
		public AplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Usuarios> Usuarios { get; set; }
	}
}
