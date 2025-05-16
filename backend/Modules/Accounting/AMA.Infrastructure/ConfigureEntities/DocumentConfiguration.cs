using AMA.Domain.Entities;
using AMA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ConfigureEntities;

public class AccountingConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Document", AccountingEntityConfiguration.Schema);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DocumentNo).IsRequired();
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Sum).IsRequired();
        builder.HasMany(x => x.DocumentDetails)
            .WithOne(x => x.Document)
            .HasForeignKey(x => x.DocumentId);
    }
}

