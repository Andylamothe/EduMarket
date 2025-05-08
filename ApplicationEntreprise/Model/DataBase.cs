using Microsoft.EntityFrameworkCore;
using Model.table;

namespace Model;
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

    /*
        * On appelle le constructeur de la classe parente
        * 
        * pour initialiser le contexte de la base de données.
        */
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=test.db");
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

        modelBuilder.Entity<Item>().ToTable("Item");

        modelBuilder.Entity<Transaction>().ToTable("Transaction");

        modelBuilder.Entity<Catalogue>().ToTable("Catalogue");
    }
}
