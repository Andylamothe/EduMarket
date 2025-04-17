using System.ComponentModel.DataAnnotations;

namespace Model.Entity.Utilisateur
{
    public abstract class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(0, 100, ErrorMessage = "La note doit être entre 0 et 100.")]
        public float Reduction { get; set; }
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
}
