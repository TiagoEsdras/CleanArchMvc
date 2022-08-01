using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(it => it.Id);

            builder
                .Property(it => it.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(it => it.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(it => it.Price)
                .HasPrecision(10, 2);

            builder
                .HasOne(it => it.Category)
                .WithMany(it => it.Products)
                .HasForeignKey(it => it.CategoryId);
        }
    }
}