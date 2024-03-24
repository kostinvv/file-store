using FileStore.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileStore.Server.Data.EntityTypeConfigurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(user => user.Id);

            builder.ToTable("application_users");

            builder.HasIndex(user => user.Name)
                .IsUnique();

            builder.Property(user => user.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasMany(user => user.StorageObjects)
                .WithOne()
                .HasForeignKey(store => store.UserId)
                .IsRequired();
        }
    }
}
