using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.table
{
    public class Catalogue
    {
        [Key]
        public int CatalogueId {  get; set; }

        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual required Item Item { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual required UserModel Users { get; set; }

    }
}
