using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Balance.Models
{
    [Table("households")]
    public class Household : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("join_code")]
        public string JoinCode { get; set; } = "";
    }
}
