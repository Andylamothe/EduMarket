using Microsoft.EntityFrameworkCore;
using Model.Entity.Utilisateur;

namespace Model.DataBase
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

    public class DataBaseUsage
    {
        public static void InitializeData(DataBase db)
        {

            if (!db.Admins.Any())
            {
                db.Admins.Add(new Admin
                {
                    FirstName = "Alice",
                    LastName = "Dupont",
                    Email = "alice.dupont@example.com",
                    Phone = "0102030405",
                    Reduction = 10
                });
            }

            if (!db.Teachers.Any())
            {
                db.Teachers.Add(new Teacher
                {
                    FirstName = "Bernard",
                    LastName = "Martin",
                    Email = "bernard.martin@example.com",
                    Phone = "0605040302",
                    Reduction = 15
                });
            }

            if (!db.Students.Any())
            {
                db.Students.Add(new Student
                {
                    FirstName = "Claire",
                    LastName = "Durand",
                    Email = "claire.durand@example.com",
                    Phone = "0701020304",
                    Reduction = 25
                });
            }

            if (!db.Departements.Any())
            {
                db.Departements.Add(new Departement
                {
                    FirstName = "Informatique",
                    LastName = "Faculté",
                    Email = "contact@info.univ.fr",
                    Phone = "0808070707",
                    Reduction = 100
                });
            }

            db.SaveChanges();
            Console.WriteLine("Données insérées dans la base.");
        }

        public static void DisplayData(DataBase db)
        {
            var admins = db.Admins.ToList();
            foreach (var admin in admins)
            {
                Console.WriteLine($"Admin: {admin.FirstName} {admin.LastName}, Email: {admin.Email}");
            }

            var teachers = db.Teachers.ToList();
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Teacher: {teacher.FirstName} {teacher.LastName}, Email: {teacher.Email}");
            }

            var students = db.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Email: {student.Email}");
            }

            var departements = db.Departements.ToList();
            foreach (var departement in departements)
            {
                Console.WriteLine($"Departement: {departement.FirstName} {departement.LastName}, Email: {departement.Email}");
            }
        }
    }
}
