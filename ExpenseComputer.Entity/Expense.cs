namespace ExpenseComputer.Entity
{
    public class Expense
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public Users User { get; set; } = new Users();
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
