using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnicornShop.Application.Models;

namespace UnicornShop.Infrastructure.Database.Mappings
{
    public sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product", "dbo");

            builder.HasKey(e => e.Id).HasName("id");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("TEXT")
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("TEXT")
                .HasMaxLength(2049);

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("INTEGER")
                .HasDefaultValue(ProductStatus.Inactive)
                .HasConversion<ProductStatus>();

            builder.Property(e => e.Quanitity)
               .HasColumnName("quanitity")
               .HasColumnType("INTEGER")
               .HasDefaultValue(0);

            builder.Property(e => e.FileId)
              .HasColumnName("file_id")
              .HasColumnType("TEXT")
              .HasMaxLength(32);

            builder.Property(e => e.CategoryId)
                .HasColumnName("category_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(e => e.PriceId)
                .HasColumnName("price_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.Price)
                .WithOne(e => e.Product)
                .HasForeignKey<Product>(e => e.PriceId)
                .IsRequired();

            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
