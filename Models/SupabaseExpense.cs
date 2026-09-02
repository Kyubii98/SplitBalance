using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Balance.Models
{
    [Table("expenses")]
    public class SupabaseExpense : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("household_id")]
        public Guid HouseholdId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("description")]
        public string Description { get; set; } = "";

        [Column("category")]
        public string Category { get; set; } = "";

        [Column("paid_by_user_id")]
        public Guid PaidByUserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}