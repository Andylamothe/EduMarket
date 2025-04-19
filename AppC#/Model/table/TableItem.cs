using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.table
{
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

    public class AccessRule
    {
        [Key]
        public int Id { get; set; }

        public int UserTypeId { get; set; }

        public required string UserTypeDiscriminator { get; set; }

        public bool CanBuy { get; set; }

        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual required Item Item { get; set; }
    }
}
