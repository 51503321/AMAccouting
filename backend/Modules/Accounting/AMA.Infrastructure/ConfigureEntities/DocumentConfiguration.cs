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
        builder.Property(x => x.DocumentNo)
            .IsRequired();
        builder.Property(x => x.Sum)
            .IsRequired();
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey(x => x.TypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.DocumentDetails)
            .WithOne(x => x.Document)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);

        /* 
         * OnDelete: This means that if you try to delete a Document that has associated DocumentDetail records,
         the database will prevent the deletion.
         */
    }
}

