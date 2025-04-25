using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.table
{
    /*
     * Cette classe va etre utiliser pour mettre un groupe a un utilisateur
     */ 
    public class Groupe
    {
        [Key]
        public int IdGroupe { get; set; }

        public required string Name { get; set; }

        public virtual required ICollection<UserModel> Users { get; set; }
        public virtual required ICollection<GroupePermission> GroupePermissions { get; set; }
    }

    public class Permission
    {
        [Key]
        public int IdPermission { get; set; }

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public bool CanUpdate { get; set; }

        public virtual required ICollection<GroupePermission> GroupePermissions { get; set; }
    }

    public class GroupePermission
    {
        [Key]
        public int IdGroupPermission { get; set; }

        public int IdGroupe { get; set; }
        [ForeignKey("IdGroupe")]
        public virtual required Groupe Groupe { get; set; }

        public int IdPermission { get; set; }
        [ForeignKey("IdPermission")]
        public virtual required Permission Permission { get; set; }


    }
}
