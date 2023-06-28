namespace ExpenseComputer.Entity
{
    public class ProductTypes
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public List<Products> Products { get; set; } = new List<Products>();
    }
}
