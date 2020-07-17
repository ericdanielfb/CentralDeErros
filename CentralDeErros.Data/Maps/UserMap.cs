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
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .HasOne(x => x.Perfil)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PerfilId)
                .IsRequired();

        }
    }
}
