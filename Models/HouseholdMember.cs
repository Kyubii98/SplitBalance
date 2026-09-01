using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Balance.Models
{
    [Table("household_members")]
    public class HouseholdMember : BaseModel
    {
        [PrimaryKey("user_id", false)]
        [Column("user_id")]
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }

        [Column("household_id")]
        [JsonProperty("household_id")]
        public Guid HouseholdId { get; set; }

        [Column("created_at")]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}