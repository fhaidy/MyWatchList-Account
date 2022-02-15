using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyWatchList.Account.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Domain.Domain.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.Domain.Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(account => account.Id);
            builder.HasIndex(account => account.Email)
                .IsUnique();
            builder.Property(account => account.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}


