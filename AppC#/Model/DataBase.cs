using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.Entity.Utilisateur;

namespace Model
{
    public class DataBase : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Departement>().ToTable("Departements");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");

            ApplyReductionConstraint<Admin>(modelBuilder);
            ApplyReductionConstraint<Teacher>(modelBuilder);
            ApplyReductionConstraint<Student>(modelBuilder);
            ApplyReductionConstraint<Departement>(modelBuilder);
        }

        [Obsolete]
        // je n'est vraiment pas trouvé quelle autre methode utiliser pour faire cela comment le HasCheckConstraint 
        private void ApplyReductionConstraint<TEntity>(ModelBuilder modelBuilder) where TEntity : class
        {
            modelBuilder.Entity<TEntity>()
                .HasCheckConstraint($"CK_{typeof(TEntity).Name}_Reduction", "[Reduction] >= 0 AND [Reduction] <= 100");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
