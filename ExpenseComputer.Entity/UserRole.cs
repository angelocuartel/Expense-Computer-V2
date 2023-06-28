namespace ExpenseComputer.Entity
{
    public class UserRole
    {
        public int Id { get; set; }
        public string RoleType { get; set; } = string.Empty;

        public List<Users> Users { get; set; } = new List<Users>();
    }
}
