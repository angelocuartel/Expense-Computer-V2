namespace ExpenseComputer.Entity
{
    public class Products
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public ProductTypes ProductType { get; set; } = new ProductTypes();
        public string Name { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
