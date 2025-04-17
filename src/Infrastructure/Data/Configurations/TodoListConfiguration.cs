using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApi.Infrastructure.Data.Configurations;

public class TodoListConfiguration : BaseAuditableEntityConfiguration<TodoList>
{
    public override void Configure(EntityTypeBuilder<TodoList> builder)
    {
        base.Configure(builder);

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .OwnsOne(b => b.Colour);

        builder.HasMany(l => l.Items)
            .WithOne(i => i.List)
            .HasForeignKey(i => i.ListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
