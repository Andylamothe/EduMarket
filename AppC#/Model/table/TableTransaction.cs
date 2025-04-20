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
        public int SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public virtual UserModel Sender { get; set; }
        public int ReceiverId { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public virtual UserModel Receiver { get; set; }

        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public virtual Item TransactionItem { get; set; }

        public bool IsActive { get; set; } = true;
    }
}