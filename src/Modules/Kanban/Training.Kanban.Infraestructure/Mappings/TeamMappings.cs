using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Domain.Teams;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Infraestructure.Mappings
{
    public class TeamMappings : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("team");

            builder.Property(t => t.Name)
                .HasColumnType("VARCHAR(45)")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("VARCHAR(255)");

            builder.HasOne(t => t.Leader)
                .WithMany(u => u.Teams)
                .HasForeignKey(t => t.LeaderId)
                .HasConstraintName("Fk_Team_User");
        }
    }
}
