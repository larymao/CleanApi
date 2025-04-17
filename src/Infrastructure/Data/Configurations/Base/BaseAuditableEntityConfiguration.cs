using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApi.Infrastructure.Data.Configurations.Base;

public class BaseAuditableEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : BaseAuditableEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Created)
            .HasColumnType("timestamp(0) with time zone");

        builder.Property(x => x.LastModified)
            .HasColumnType("timestamp(0) with time zone");
    }
}
