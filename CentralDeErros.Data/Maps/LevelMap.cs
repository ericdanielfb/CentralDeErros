using CentralDeErros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CentralDeErros.Data.Maps
{
    class LevelMap : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder
                .ToTable("level");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("idLevel")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varvhar")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .HasMany(x => x.Errors)
                .WithOne(x => x.Level);
        }
    }
}
