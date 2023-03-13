using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnicornShop.Application.Models;

namespace UnicornShop.Infrastructure.Database.Mappings
{
    public sealed class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("TEXT")
                .HasMaxLength(254)
                .IsRequired();

            builder.HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);

            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
