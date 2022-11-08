using Microsoft.EntityFrameworkCore;
using WebApplicationMVCEjemplo.Models;

namespace WebApplicationMVCEjemplo.DataEF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; } 
    }
}
