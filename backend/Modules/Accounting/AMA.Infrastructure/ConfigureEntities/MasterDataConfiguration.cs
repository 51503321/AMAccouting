using AMA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMA.Infrastructure.ConfigureEntities;

public class MasterDataConfiguration : IEntityTypeConfiguration<MasterData>
{
    public void Configure(EntityTypeBuilder<MasterData> builder)
    {
        builder.ToTable("MasterData", AccountingEntityConfiguration.Schema);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code)
            .IsRequired();
        builder.Property(x => x.Name)
            .IsRequired();
    }
}