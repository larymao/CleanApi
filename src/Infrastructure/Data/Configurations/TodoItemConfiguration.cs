using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApi.Infrastructure.Data.Configurations;

public class TodoItemConfiguration : BaseAuditableEntityConfiguration<TodoItem>
{
    public override void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        base.Configure(builder);

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}
