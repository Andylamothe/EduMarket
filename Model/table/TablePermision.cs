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
        public int GroupeId { get; set; }

        public required string Name { get; set; }

        [ForeignKey("PermissionId")]
        public virtual required Permission Permission { get; set; }

        public override string ToString()
        {
            return "Groupe{ID:" + GroupeId + ", Name: " + Name + ", Permission" + Permission;
        }
    }

    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public bool CanUpdate { get; set; }

        public override string ToString()
        {
            return "Permission{ID:" + PermissionId + ", CanRead: " + CanRead + ", CanWrite: " + CanWrite + ", CanUpdate: " + CanUpdate + "}";
        }
    }
}
