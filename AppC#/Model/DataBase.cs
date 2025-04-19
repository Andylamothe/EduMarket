using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.repository;
using Model.table;

namespace Model.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<AccessRule> AccessRules { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .ToTable("Utilisateur")
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Admin>("Admin")
                .HasValue<Teacher>("Teacher")
                .HasValue<Student>("Student")
                .HasValue<Departement>("Departement");

            modelBuilder.Entity<Item>().ToTable("Item");

            modelBuilder.Entity<AccessRule>().ToTable("ItemAcces");

            modelBuilder.Entity<Transaction>().ToTable("Transaction");
        }
    }
    public class DataBaseUsage
    {
        public static void InitializeData(IServiceProvider provider)
        {
            AddIfEmpty(provider, new Admin
            {
                FirstName = "Alice",
                LastName = "Dupont",
                Email = "alice.dupont@example.com",
                Phone = "0102030405",
                Login = "alice.dupont",
                Password = "1234"
            });

            AddIfEmpty(provider, new Teacher
            {
                FirstName = "Bernard",
                LastName = "Martin",
                Email = "bernard.martin@example.com",
                Phone = "0605040302",
                Login = "bernard.martin",
                Password = "1234"
            });

            AddIfEmpty(provider, new Student
            {
                FirstName = "Claire",
                LastName = "Durand",
                Email = "claire.durand@example.com",
                Phone = "0701020304",
                Login = "claire.durand",
                Password = "1234"
            });

            AddIfEmpty(provider, new Departement
            {
                FirstName = "Informatique",
                LastName = "Faculté",
                Email = "contact@info.univ.fr",
                Phone = "0808070707",
                Login = "informatique",
                Password = "1234"
            });
        }

        private static void AddIfEmpty<TEntity>(IServiceProvider provider, TEntity entity) where TEntity : class
        {
            var repository = provider.GetRequiredService<IRepository<TEntity>>();
            if (!repository.GetAllAsync().Result.Any())
            {
                repository.AddAsync(entity).Wait();
                Console.WriteLine($"{typeof(TEntity).Name} ajouté avec succès.");
            }
        }

        public static void DisplayData<TEntity>(IServiceProvider provider) where TEntity : class
        {
            var repository = provider.GetRequiredService<IRepository<TEntity>>();
            var entities = repository.GetAllAsync().Result;

            foreach (var entity in entities)
            {
                Console.WriteLine(entity?.ToString());
            }
        }
    }
}
