using LevvaCoins.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevvaCoins.Infra.Data.Configuration
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(x => x.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal")
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.Property(x => x.CategoryId)
                .HasColumnName("categoryId");

            builder.Property(x => x.UserId)
                .HasColumnName("userId");

            //builder.OwnsOne(x => x.Description, descriptionBuilder =>
            //{
            //    descriptionBuilder.Property(x => x.Text)
            //        .HasColumnName("description")
            //        .HasColumnType("VARCHAR")
            //        .HasMaxLength(255)
            //        .IsRequired();
            //});
            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
