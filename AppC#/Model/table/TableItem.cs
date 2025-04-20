using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.table
{
    /*
     * La classe item va etre utiliser dans le catalogues aussi, car le catalogue va contenir des items.
     */
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Description { get; set; }
    }

    /*
     * Cette classe est la pour definir les droits d'acces de chaque type d'utilisateur sur un item.
     * 
     * Pour gerer la visibilite de chaque items
     */
    public class AccessRule
    {
        [Key]
        public int Id { get; set; }

        // Ce champ va etre utiliser pour savoir quel type d'utilisateur a le droit d'acceder a l'item.
        // Student, Teacher, Departement, Admin (moi qui va gerer cela)
        public required string UserTypeDiscriminator { get; set; }

        public bool CanBuy { get; set; }

        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual required Item Item { get; set; }
    }
}
