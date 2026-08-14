namespace Balance.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string PaidBy { get; set; } = "";
        public decimal MyShare { get; set; } = 50;
    }
}
