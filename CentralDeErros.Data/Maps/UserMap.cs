using CentralDeErros.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnName("user_name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(x => x.Profile)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ProfileId)
                .IsRequired();

        }
    }
}
