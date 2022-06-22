using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Domain.Boards;

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
                .WithMany(u => u.Boards)
                .HasForeignKey(b => b.LeaderId)
                .HasConstraintName("Fk_Board_User");
        }
    }
}
