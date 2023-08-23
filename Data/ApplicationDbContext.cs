using Microsoft.EntityFrameworkCore;
using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FormRegister> FormRegisters { get; set; }
    }
}
