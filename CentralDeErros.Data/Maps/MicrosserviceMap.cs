using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Core.Models.Maps
{
    public class MicrosserviceMap : IEntityTypeConfiguration<Microsservice>
    {
        public void Configure(EntityTypeBuilder<Microsservice> builder)
        {

            builder
                .ToTable("microservice");

            builder
                .HasKey(k => k.Id);

            builder
                .Property(k => k.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(k => k.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(k => k.Occurrences)
                .WithOne(a => a.Microsservice)
                .IsRequired();
        }
    }
}
