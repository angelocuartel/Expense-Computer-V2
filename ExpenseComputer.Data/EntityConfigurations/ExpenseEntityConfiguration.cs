using ExpenseComputer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseComputer.Data.EntityConfigurations
{
    public class ExpenseEntityConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.User)
                .WithMany(i => i.Expenses)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(i => i.Amount)
                .HasPrecision(18, 2);
        }
    }
}
