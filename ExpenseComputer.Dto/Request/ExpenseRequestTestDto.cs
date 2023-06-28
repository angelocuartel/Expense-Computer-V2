namespace ExpenseComputer.Dto.Request
{
    public class ExpenseRequestTestDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
