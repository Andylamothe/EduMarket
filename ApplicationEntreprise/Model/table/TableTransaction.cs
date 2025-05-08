using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.table
{
    /*
     * Cette classes est la pour faire les transactions entre les differents utilisateurs.
     */
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        
        public int ReceiverId { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public virtual required UserModel Receiver { get; set; }

        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public virtual required Item TransactionItem { get; set; }

        public bool IsActive { get; set; } = true;
    }
}