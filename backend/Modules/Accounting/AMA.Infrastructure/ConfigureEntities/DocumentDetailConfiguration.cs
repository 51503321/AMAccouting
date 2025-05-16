using AMA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMA.Infrastructure.ConfigureEntities;

public class DocumentDetailConfiguration : IEntityTypeConfiguration<DocumentDetail>
{
    public void Configure(EntityTypeBuilder<DocumentDetail> builder)
    {
        builder.ToTable("DocumentDetail", AccountingEntityConfiguration.Schema);
        builder.Property(x => x.AccountNo).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.HasOne(x => x.TransactionType)
            .WithMany()
            .HasForeignKey(x => x.TransactionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasKey(x => x.Id);
    }
}
