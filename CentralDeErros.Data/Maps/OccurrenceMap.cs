using CentralDeErros.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentralDeErros.Model.Maps
{
    public class OccurrenceMap : IEntityTypeConfiguration<Occurrence>
    {
        public void Configure(EntityTypeBuilder<Occurrence> builder)
        {
            builder
                .ToTable("occurrence");

            builder
                .HasKey(k => k.Id);

            builder
                .Property(k => k.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(k => k.Details)
                .HasColumnName("details")
                .HasColumnType("varchar(250)")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(k => k.Origin)
                .HasColumnName("origin")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(k => k.OccurrenceDate)
                .HasColumnName("occurrence_date")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .HasOne(k => k.Microsservice)
                .WithMany(s => s.Occurrences)
                .HasForeignKey(x => x.MicrosserviceId)
                .IsRequired();

            builder
                .HasOne(x => x.Environment)
                .WithMany(x => x.Occurrences)
                .HasForeignKey(x => x.EnviromentId)
                .IsRequired();

            builder
                .HasOne(x => x.Error)
                .WithMany(x => x.Occurrences)
                .HasForeignKey(x => x.ErrorId)
                .IsRequired();


        }
    }
}
