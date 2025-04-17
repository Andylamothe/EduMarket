using System.ComponentModel.DataAnnotations;

namespace Model
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
        
    }

    public class Departement : UserModel 
    { 

    }

    public class Teacher : UserModel
    {

    }

    public class Student : UserModel
    {

    }
}
