using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Balance.Models
{
    [Table("expense_splits")]
    public class ExpenseSplit : BaseModel
    {
        [PrimaryKey("expense_id", false)]
        [Column("expense_id")]
        public Guid ExpenseId { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("share_percent")]
        public decimal SharePercent { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}