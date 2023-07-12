using LevvaCoins.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevvaCoins.Infra.Data.Mappings
{
    public class CategoryMap: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.OwnsOne(x => x.Description, descriptionBuilder =>
            {
                descriptionBuilder.Property(x => x.Text)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(50)
                    .IsRequired();
                descriptionBuilder.Ignore(x => x.Notifications);
                descriptionBuilder.HasIndex(x => x.Text).IsUnique();
            });
            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
