using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CentralDeErros.Model.Models;


namespace CentralDeErros.Model.Maps
{
    class EnvironmentMap : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder
                .ToTable("environment");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Phase)
                .HasColumnName("phase")
                .HasColumnType("varchar(32)")
                .HasMaxLength(32)
                .IsRequired();

            builder
                .HasMany(x => x.Occurrences)
                .WithOne(x => x.Environment);
        }
    }
}
