using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.repository;
using Model.table;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.DataBase
{
    public class DataBaseContext : DbContext
    {
        /*
         * DbSet sont les tables de ma base de donnees et ces ceux-ci qu'on va utiliser dans les ViewModels. 
         */
        public DbSet<UserModel> Users { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Catalogue> Catalogues { get; set; }

        public DbSet<Groupe> Groupes { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<GroupePermission> PermissionsPermission { get; set; }

        /*
         * On appelle le constructeur de la classe parente
         * 
         * pour initialiser le contexte de la base de données.
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db/test.db");
            optionsBuilder.UseLazyLoadingProxies();
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
                .HasValue<Admin>(DiscriminantTableUtilisateur.ADMIN)
                .HasValue<Teacher>(DiscriminantTableUtilisateur.TEACHER)
                .HasValue<Student>(DiscriminantTableUtilisateur.STUDENT)
                .HasValue<Departement>(DiscriminantTableUtilisateur.DEPARTEMENT);

            modelBuilder.Entity<Groupe>().ToTable("Groupe");

            modelBuilder.Entity<Permission>().ToTable("Permission");

            modelBuilder.Entity<GroupePermission>().ToTable("GroupePermission");

            modelBuilder.Entity<Item>().ToTable("Item");

            modelBuilder.Entity<Transaction>().ToTable("Transaction");

            modelBuilder.Entity<Catalogue>().ToTable("Catalogue");
        }
    }

    /*
     * Cette class est seulement la pour plus facilement ajouter des donnes dans la base de donnees, un peu comme en java avec spring boot
     */
    public class DataBaseUsage
    {
        public static void InitializeData(IServiceProvider provider)
        {
            
        }

        private static void Add<TEntity>(IServiceProvider provider, TEntity entity) where TEntity : class
        {
<<<<<<< HEAD
            var repository = provider.GetRequiredService<IRepository<TEntity>>();
            repository.AddAsync(entity);
=======
            provider.GetRequiredService<IRepository<TEntity>>().AddAsync(entity);
>>>>>>> 19c22d0350940440ffe99683d3ae64114b539b77
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