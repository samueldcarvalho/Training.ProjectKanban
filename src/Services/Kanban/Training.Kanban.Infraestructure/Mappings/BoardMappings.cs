using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Domain.Boards;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Infraestructure.Mappings
{
    public class BoardMappings : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("board");

            builder.Property(b => b.Name)
                .HasColumnType("VARCHAR(45)")
                .IsRequired();

            builder.Property(b => b.Description)
                .HasColumnType("VARCHAR(255)");

            builder.HasOne(b => b.Leader)
                .WithMany()
                .HasForeignKey(b => b.LeaderId)
                .HasConstraintName("Fk_Board_User");

            builder.HasMany(b => b.Members)
                .WithMany(u => u.Boards)
                .UsingEntity<Dictionary<string, object>>("_board_users_m2m",
                    b => b.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    b => b.HasOne<Board>().WithMany().HasForeignKey("BoardId"));
        }
    }
}
