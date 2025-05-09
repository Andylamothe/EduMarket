using Microsoft.EntityFrameworkCore;
using Model.table;
using System.Text.RegularExpressions;

namespace Model;
public class DataBaseContext : DbContext
{
    /*
        * DbSet sont les tables de ma base de donnees et ces ceux-ci qu'on va utiliser dans les ViewModels. 
        */
    public DbSet<UserModel> Users { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Groupe> Groupes { get; set; }

    public DbSet<Permission> Permissions { get; set; }

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

        modelBuilder.Entity<Item>().ToTable("Item");

        modelBuilder.Entity<Transaction>().ToTable("Transaction");
    }

    public static class DbInitializer
    {

        public static void Seed(DataBaseContext context)
        {
            if (!context.Permissions.Any() && !context.Groupes.Any() && !context.Users.Any())
            {
                var permission1 = new Permission() { CanRead = true, CanUpdate = true, CanWrite = true };
                var permission2 = new Permission() { CanRead = true, CanUpdate = false, CanWrite = false };
                var permission3 = new Permission() { CanRead = true, CanUpdate = false, CanWrite = true };

                context.Permissions.AddRange(permission1, permission2, permission3);

                var groupe1 = new Groupe() { Name = "Admin", Permission = permission1 };
                var groupe2 = new Groupe() { Name = "Teacher", Permission = permission2 };
                var groupe3 = new Groupe() { Name = "Student", Permission = permission3 };

                context.Groupes.AddRange(groupe1, groupe2, groupe3);

                var admin = new Admin
                {
                    FirstName = "Alice",
                    LastName = "Admin",
                    Email = "admin@example.com",
                    Phone = "0000000001",
                    Login = "admin",
                    Password = "1234",
                    GroupeUser = groupe1
                };

                var student = new Student
                {
                    FirstName = "Bob",
                    LastName = "Student",
                    Email = "bob@student.com",
                    Phone = "0000000002",
                    Login = "bob",
                    Password = "1234",
                    GroupeUser = groupe2
                };

                var teacher = new Teacher
                {
                    FirstName = "Claire",
                    LastName = "Teacher",
                    Email = "claire@teacher.com",
                    Phone = "0000000003",
                    Login = "claire",
                    Password = "1234",
                    GroupeUser = groupe3
                };

                var departement = new Departement
                {
                    FirstName = "Dept",
                    LastName = "Head",
                    Email = "dept@school.com",
                    Phone = "0000000004",
                    Login = "dept",
                    Password = "1234",
                    GroupeUser = groupe1
                };

                context.Users.AddRange(admin, student, teacher, departement);

                var item1 = new Item
                {
                    Name = "Item 1",
                    Description = "Description of item 1",
                    Price = 10.0f,
                    Customer = student,
                };

                var item2 = new Item
                {
                    Name = "Item 2",
                    Description = "Description of item 2",
                    Price = 10.0f,
                    Customer = student,
                };

                var item3 = new Item
                {
                    Name = "Item 3",
                    Description = "Description of item 3",
                    Price = 10.0f,
                    Customer = teacher
                };

                var item4 = new Item
                {
                    Name = "Item 4",
                    Description = "Description of item 4",
                    Price = 10.0f,
                    Customer = departement
                };

                var item5 = new Item
                {
                    Name = "Item 5",
                    Description = "Description of item 5",
                    Price = 10.0f,
                    Customer = departement
                };

                var item6 = new Item
                {
                    Name = "Item 6",
                    Description = "Description of item 6",
                    Price = 10.0f,
                    Customer = departement
                };

                context.Items.AddRange(item1, item2, item3, item4, item5, item6);

                context.SaveChanges();
            }
        }
    }
}
