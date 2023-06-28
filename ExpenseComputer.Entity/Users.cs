namespace ExpenseComputer.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? Name { get; set; } 
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserRole UserRole { get; set; } = new UserRole();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
