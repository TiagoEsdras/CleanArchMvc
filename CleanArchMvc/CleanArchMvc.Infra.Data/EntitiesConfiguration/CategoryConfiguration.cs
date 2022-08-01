using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(it => it.Id);

            builder
                .Property(it => it.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasData(
                    new Category(1, "Eletronic"),
                    new Category(2, "Cellphone"),
                    new Category(3, "Notebook")
                );
        }
    }
}