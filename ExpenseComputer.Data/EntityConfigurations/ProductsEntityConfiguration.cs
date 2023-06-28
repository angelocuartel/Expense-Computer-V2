using ExpenseComputer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseComputer.Data.EntityConfigurations
{
    public class ProductsEntityConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.ProductType)
                .WithMany(i => i.Products)
                .HasForeignKey(i => i.ProductTypeId);
        }
    }
}
