using CentralDeErros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Core.Models.Maps
{
    public class OccurrenceMap : IEntityTypeConfiguration<Occurrence>
    {
        public void Configure(EntityTypeBuilder<Occurrence> builder)
        {

            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(k => k.Microsservice)
                .WithMany(s => s.Occurrences);

            builder
                .Property(k => k.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(k => k.Details)
                .HasColumnName("details")
                .IsRequired();

            builder
                .Property(k => k.Origin)
                .HasColumnName("origin")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(k => k.OccurrenceDate)
                .HasColumnName("occurrence_date")
                .IsRequired();

        }

    }
}
