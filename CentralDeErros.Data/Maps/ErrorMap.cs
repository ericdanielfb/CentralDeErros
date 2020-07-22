using CentralDeErros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Data.Maps
{
    class ErrorMap : IEntityTypeConfiguration<Error>
    {

        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder
                .ToTable("Error");

            builder
               .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();


            builder
                .Property(x => x.Description)
                .HasColumnName("description")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property(x => x.LevelId)
                .HasColumnName("level_id")
                .HasColumnType("int")
                .IsRequired();

            builder
                .HasOne(x => x.Level)
                .WithMany(x => x.Errors)
                .HasForeignKey(x => x.LevelId);
        }
    }
}