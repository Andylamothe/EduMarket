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
        public required string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public required string Description { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual required UserModel Customer { get; set; }
    }
}
