using FileStore.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileStore.Server.Data.EntityTypeConfigurations;

public class StorageObjectConfiguration : IEntityTypeConfiguration<StorageObject>
{
    public void Configure(EntityTypeBuilder<StorageObject> builder)
    {
        builder.HasKey(store => store.Id);

        builder.ToTable("storage_objects");

        builder
            .HasIndex(store => store.Name)
            .IsUnique();
    }
}