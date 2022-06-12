using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Infraestructure.Mappings
{
    public class UserMappings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(x => x.Username)
                .HasColumnType("VARCHAR(26)");

            builder.Property(x => x.Password)
                .HasColumnType("VARCHAR(26)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.HasIndex(x => x.Username)
                .IsUnique();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => new { x.Username, x.Password })
                .HasName("ix_LoginData");

            
        }
    }
}
