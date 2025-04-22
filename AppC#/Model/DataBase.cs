using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.repository;
using Model.table;

namespace Model.DataBase
{
    public class DataBaseContext : DbContext
    {
        /*
         * DbSet sont les tables de ma base de donnees et ces ceux-ci qu'on va utiliser dans les ViewModels. 
         */
        public DbSet<UserModel> Users { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<AccessRule> AccessRules { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Catalogue> Catalogues { get; set; }

        /*
         * On appelle le constructeur de la classe parente
         * 
         * pour initialiser le contexte de la base de données.
         */
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        /*
         * Cette méthode est appelée lors de la création du modèle de données.
         * En gros, cette methodes est utiliser pour configurer le modèle de données.
         * Ces a ce moment la que je definit les tables et relation de ma base de donnees.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .ToTable("Utilisateur")
                .HasDiscriminator<string>("Role")
                .HasValue<Admin>("Admin")
                .HasValue<Teacher>("Teacher")
                .HasValue<Student>("Student")
                .HasValue<Departement>("Departement");

            modelBuilder.Entity<Item>().ToTable("Item");

            modelBuilder.Entity<AccessRule>().ToTable("ItemAcces");

            modelBuilder.Entity<Transaction>().ToTable("Transaction");

            modelBuilder.Entity<Catalogue>().ToTable("");
        }
    }

    // Cette class est seulement la pour plus facilement ajouter des donnes dans la base de donnees, un peu comme en java avec spring boot
    public class DataBaseUsage
    {
        public static void InitializeData(IServiceProvider provider)
        {
            Add(provider, new Admin
            {
                FirstName = "Alice",
                LastName = "Dupont",
                Email = "alice.dupont@example.com",
                Phone = "0102030405",
                Login = "alice.dupont",
                Password = "1234"
            });

            Add(provider, new Teacher
            {
                FirstName = "Bernard",
                LastName = "Martin",
                Email = "bernard.martin@example.com",
                Phone = "0605040302",
                Login = "bernard.martin",
                Password = "1234"
            });

            Add(provider, new Student
            {
                FirstName = "Claire",
                LastName = "Durand",
                Email = "claire.durand@example.com",
                Phone = "0701020304",
                Login = "claire.durand",
                Password = "1234"
            });

            Add(provider, new Departement
            {
                FirstName = "Informatique",
                LastName = "Faculté",
                Email = "contact@info.univ.fr",
                Phone = "0808070707",
                Login = "informatique",
                Password = "1234"
            });
        }

        private static void Add<TEntity>(IServiceProvider provider, TEntity entity) where TEntity : class
        {
            var repository = provider.GetRequiredService<IRepository<TEntity>>();
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
