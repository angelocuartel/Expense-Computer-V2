using ExpenseComputer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseComputer.Data.EntityConfigurations
{
    public class ProductTypesEntityConfiguration : IEntityTypeConfiguration<ProductTypes>
    {
        public void Configure(EntityTypeBuilder<ProductTypes> builder)
        {
            builder.HasKey(i => i.Id);
        }
    }
}
