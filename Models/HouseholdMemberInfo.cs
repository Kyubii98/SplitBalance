using Newtonsoft.Json;

namespace Balance.Models
{
    public class HouseholdMemberInfo
    {
        [JsonProperty("user_id")]
        public Guid UserId { get; set; }

        [JsonProperty("household_id")]
        public Guid HouseholdId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; } = "";
    }
}