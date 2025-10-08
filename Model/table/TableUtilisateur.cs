﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model.table
{
    /*
     * Cette classe est la classe de base pour tout les types d'utilisateur.
     * 
     * L'attribut Reduction est la pour definir la reduction de chaque utilisateur, selon leur achat qu'il vont faire.
     * 
     * utilisation d'une classe abstract pour ne pas pouvoir instancier un UserModel
     * (il n'est pas possible de faire new UserModel)(impossible)
     */
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Phone { get; set; }

        [Required]
        public required string Login { get; set; }

        [Required]
        public required string Password { get; set; }

        [Range(0, 100, ErrorMessage = "La reduction doit être entre 0 et 100.")]
        public float Reduction { get; set; }

        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual required Groupe GroupeUser { get; set; }

        public bool IsActive { get; set; } = true;


        public override string ToString()
        {
            return "UserModel{" +
                "IdUser: " + this.UserId +
                ", FirstName: " + this.FirstName +
                ", LastName: " + this.LastName +
                ", Email: " + this.Email +
                ", Phone: " + this.Phone +
                ", Login: " + this.Login +
                ", Password: " + this.Password +
                ", Reduction: " + this.Reduction +
                ", IsActive: " + this.IsActive +
                ", Groupe" + this.GroupeUser +
                "}";
        }
    }

    public class Admin : UserModel
    {

        public Admin()
        {
            Reduction = 0;
        }


    }

    public class Departement : UserModel
    {
        public Departement()
        {
            Reduction = 100;
        }
    }

    public class Teacher : UserModel
    {

        public Teacher()
        {
            Reduction = 15;
        }
    }

    public class Student : UserModel
    {

        public Student()
        {
            Reduction = 30;
        }

    }

    public static class DiscriminantTableUtilisateur
    {
        public static readonly string ADMIN = "admin";
        public static readonly string STUDENT = "student";
        public static readonly string TEACHER = "teacher";
        public static readonly string DEPARTEMENT = "departement";
    }
}
