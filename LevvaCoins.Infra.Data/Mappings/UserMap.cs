using LevvaCoins.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevvaCoins.Infra.Data.Mappings
{
    public class UserMap: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(x => x.Avatar)
                .HasColumnName("avatar")
                .HasColumnType("VARCHAR")
                .HasMaxLength(2000);

            builder.HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
