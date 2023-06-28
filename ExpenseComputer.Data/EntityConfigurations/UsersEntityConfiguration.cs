using ExpenseComputer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseComputerAPI.Models.EntityConfigurations
{
    public class UsersEntityConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.UserRole)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.RoleId);
        }
    }
}
