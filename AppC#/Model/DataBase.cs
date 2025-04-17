using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class DataBase : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public DataBase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=product.db");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Departement>().ToTable("Departements");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
