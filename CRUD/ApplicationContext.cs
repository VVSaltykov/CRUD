using CRUD.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=cruddb; User Id=sa; Password=myStrongPassword123; TrustServerCertificate=True");
        }
    }
}
